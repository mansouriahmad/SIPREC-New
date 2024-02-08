using System.Net.NetworkInformation;
using SIPREC_New;

namespace SIPREC;

class Program
{
  static void Main(string[] args)
  {

    MyEndpoint endpoint = new MyEndpoint();

    try
    {
      endpoint.libCreate();
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex.Message);
    }


    EpConfig epConfig = new EpConfig();
    try
    {
      endpoint.libInit(epConfig);
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex.Message);
    }

    int id = 0;
    try
    {
      TransportConfig transportConfig = new TransportConfig();
      transportConfig.port = 5060;
      id = endpoint.transportCreate(pjsip_transport_type_e.PJSIP_TRANSPORT_UDP, transportConfig);
      int id2 = endpoint.transportCreate(pjsip_transport_type_e.PJSIP_TRANSPORT_TCP, transportConfig);
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex.Message);
    }


    try
    {
      endpoint.libStart();
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex.Message);
    }


    AccountConfig accountConfig = new AccountConfig();
    AccountSipConfig accountSipConfig = new AccountSipConfig();
    accountSipConfig.transportId = id;
    accountConfig.sipConfig = accountSipConfig;
    Console.WriteLine(accountConfig.sipConfig.authCreds);
    accountConfig.idUri = "sip:192.168.0.41:5060";
    MyAccount myAccount = new MyAccount();


    try
    {
      myAccount.create(accountConfig);
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex.Message);
    }




    string userInput = Console.ReadLine();

    
    myAccount.Dispose();
    endpoint.libDestroy();



  }
}