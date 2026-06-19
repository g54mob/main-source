using Aggro.Core;

public class NitroUI : EntityBehaviourBase
{
	public NitroBarUI[] nitroBars;

	protected override void OnUpdatePresentation()
	{
		if (!GameUtil.TryGetLocalPlayer(out var player))
		{
			return;
		}
		NitroController nitroController = player.GetObject<NitroController>();
		int num = nitroController.LocalPlayerGetChargeCount();
		for (int i = 0; i < num; i++)
		{
			nitroBars[i].gameObject.SetActive(value: true);
			if (i < nitroController.nitroCharges)
			{
				nitroBars[i].SetFull();
			}
			else if (i > nitroController.nitroCharges)
			{
				nitroBars[i].SetEmpty();
			}
			else if (i == nitroController.nitroCharges)
			{
				if (nitroController.nitroActiveSync)
				{
					nitroBars[i].SetFill(1f - nitroController.nitroBurnProgress, nitroActive: true);
				}
				else
				{
					nitroBars[i].SetFill(nitroController.nitroBuildUpLevel);
				}
			}
		}
		for (int j = num; j < nitroBars.Length; j++)
		{
			nitroBars[j].gameObject.SetActive(value: false);
		}
	}
}
