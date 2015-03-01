using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using Twilio;

namespace SmsASMX
{
    /// <summary>
    /// Summary description for SMSws
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    public class SMSws : System.Web.Services.WebService
    {
        //BUDDU
        string TwilioAccountSid = "AC7c35d6d25a694ba957e5243c9c5be4f0";
        string TwilioAuthToken = "7c2eae4ce023b4f1fcd1b7c7db721acd";
        string TwilioFROM = "+19195825957"; 

        [WebMethod]
        public string HelloWorld(string id)
        {
            return "Hello World"  + id ;
        }

        [WebMethod]
        public string SendText(string phone, string message)
        {
            //  return string.Format("Message is sent to {0} from {1}", PhoneNumber, Name);
            TwilioRestClient twilioRClient = new TwilioRestClient(TwilioAccountSid, TwilioAuthToken);
            SMSMessage smsMessage = new SMSMessage();
            Message twMessage = new Message(); 
            smsMessage.Status = "Message not delivered";

            if (phone != null && twMessage != null)
            {
                try
                {
                    twMessage = twilioRClient.SendMessage(TwilioFROM, "+1" + phone, message); 
                   // smsMessage = twilioRClient.SendSmsMessage(TwilioFROM, "+1" + phone, message);
                }
                catch (Exception ex)
                {

                }
                if (smsMessage.Status != null)
                {
                    smsMessage.Status = "Message to Sent " + phone;

                }
                if (twMessage.Status != null)
                {
                 
                    twMessage.Status = "Message to Sent " + phone;
                }
            }
            //return smsMessage.Status;
            return twMessage.Status; 
        }

    }
}
