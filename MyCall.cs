namespace SIPREC_New
{
  public class MyCall : Call
  {
    public MyCall(Account account, int call_id = (int)pjsua_invalid_id_const_.PJSUA_INVALID_ID) : base(account, call_id)
    {
    }

    ~MyCall()
    {

    }

    public override void onCallState(OnCallStateParam prm)
    {
      CallInfo ci = getInfo();
      if (ci.state == pjsip_inv_state.PJSIP_INV_STATE_DISCONNECTED)
      {
        /* Delete the call */
        this.Dispose();
      }
    }

    public override void onCallMediaState(OnCallMediaStateParam prm)
    {
    }
  }
}