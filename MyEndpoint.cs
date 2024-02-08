using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace SIPREC_New
{
  public class MyEndpoint : Endpoint
  {
    public MyEndpoint() : base()
    {

    }

    protected override void Dispose(bool disposing)
    {
      Console.WriteLine("Endpoint disposing");
      base.Dispose(disposing);
    }

    public override void onRejectedIncomingCall(OnRejectedIncomingCallParam prm)
    {
      try
      {
        ;
        Console.WriteLine(prm.localInfo);
        Console.WriteLine(prm.reason);
      }
      catch (Exception ex)
      {
        Console.WriteLine("onRejectedIncomingCall" + ex.Message);
      }
    }

    public override void onTransportState(OnTransportStateParam prm)
    {
      try
      {
        Console.WriteLine("onTransportState" + prm.state);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }

    public override void onSelectAccount(OnSelectAccountParam prm)
    {
      try
      {
        Console.WriteLine("onSelectAccount" + prm.rdata.srcAddress + " " + prm.accountIndex + " " + prm.rdata.info);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }
  }


}