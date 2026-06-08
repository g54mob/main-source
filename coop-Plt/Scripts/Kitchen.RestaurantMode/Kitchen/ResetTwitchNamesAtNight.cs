namespace Kitchen
{
	public class ResetTwitchNamesAtNight : StartOfNightSystem
	{
		protected override void OnUpdate()
		{
			base.EntityManager.CreateEntity(typeof(TwitchNameList.CReshuffleNameList));
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
