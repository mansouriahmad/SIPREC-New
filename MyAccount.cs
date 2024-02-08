using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIPREC_New
{
  public class MyAccount : Account
  {
    public MyAccount()
    {

    }

    ~MyAccount()
    {
      Console.WriteLine("Destructor for account: " + this.getId());
    }

    protected override void Dispose(bool disposing)
    {
      Console.WriteLine("Disposing account" + this.getId());
      base.Dispose(disposing);
    }

    public override void onRegState(OnRegStateParam prm)
    {
      try
      {
        AccountInfo accountInfo = getInfo();
        Console.WriteLine(accountInfo.regIsActive ? "*** Register: code= " : "*** Unregister: code= " + prm.code);
      }
      catch (Exception ex)
      {
        Console.WriteLine("onRegState" + ex.Message);
      }
    }

    public override void onIncomingCall(OnIncomingCallParam prm)
    {
      try
      {
        Console.WriteLine("OnIncoming Call is triggered");
        using Call call = new MyCall(this, prm.callId);
        CallInfo callInfo = call.getInfo();
        Console.WriteLine("*** Incoming call: " + callInfo.remoteUri + " [" + callInfo.stateText + "] ");

        // Just hang up for now
        CallOpParam callOpParam = new CallOpParam();
        callOpParam.statusCode = pjsip_status_code.PJSIP_SC_DECLINE;
        call.hangup(callOpParam);
      }
      catch (Exception ex)
      {
        Console.WriteLine("onIncomingCall" + ex.Message);
      }
    }

  }
}