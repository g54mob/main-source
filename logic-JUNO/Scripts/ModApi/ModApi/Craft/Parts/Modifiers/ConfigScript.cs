namespace ModApi.Craft.Parts.Modifiers
{
	public class ConfigScript : PartModifierScript<ConfigData>
	{
		private bool _bodiesOutdated = true;

		private int _bodyId;

		public int GetBodyId()
		{
			if (_bodiesOutdated)
			{
				_bodiesOutdated = false;
				Game.Instance.Designer.CreateCraftBodyDatas();
				BodyData bodyByPartId = base.PartScript.CraftScript.Data.Assembly.GetBodyByPartId(base.PartScript.Data.Id);
				if (bodyByPartId != null)
				{
					_bodyId = bodyByPartId.Id;
				}
			}
			return _bodyId;
		}

		public override void OnCraftStructureChanged(ICraftScript craftScript)
		{
			base.OnCraftStructureChanged(craftScript);
			_bodiesOutdated = true;
			base.Data.OnDesignerCraftStructureChanged();
		}
	}
}
