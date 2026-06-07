namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class CatapultConnectorScript : PartModifierScript
	{
		private CatapultConnectorData _connector;

		public float CatapultAcceleration => _connector.CatapultAcceleration;

		public float TargetLaunchSpeed => _connector.TargetLaunchSpeed;

		public void Initialize(CatapultConnectorData catapultConnector)
		{
			_connector = catapultConnector;
			if (base.PartScript.LoadContext != CraftLoadContext.Designer)
			{
				base.PartScript.gameObject.SetActive(value: false);
			}
		}
	}
}
