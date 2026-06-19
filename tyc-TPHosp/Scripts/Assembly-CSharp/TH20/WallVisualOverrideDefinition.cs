using UnityEngine;

namespace TH20
{
	[CreateAssetMenu(menuName = "TH20/Wall Visual Override Definition", order = 1032)]
	public class WallVisualOverrideDefinition : ScriptableObjectWithID, IWallVisualOverrideDefinition, ISilverUnlockable, ISilverUnlockToken
	{
		[SerializeField]
		private LocalisedString _name;

		[SerializeField]
		private LocalisedString _description;

		[SerializeField]
		private Sprite _icon;

		[SerializeField]
		private Texture2D _diffuseTexture;

		[SerializeField]
		private int _silverCost;

		public ISilverUnlockToken SilverUnlockToken => this;

		public Sprite Icon => _icon;

		public string Name => _name.Translation;

		public string Description => _description.Translation;

		public int SilverCost()
		{
			return _silverCost;
		}

		public LocalisedString GetUnlockName()
		{
			return new LocalisedString(string.Empty);
		}

		public LocalisedString GetUnlockMessage()
		{
			return new LocalisedString(string.Empty);
		}

		public Sprite GetUnlockIcon()
		{
			return Icon;
		}

		public ESandboxCheckType GetSandboxCheckType()
		{
			return ESandboxCheckType.RoomItems;
		}

		public string GetContentID()
		{
			return string.Empty;
		}

		public Texture2D GetDiffuseTexture()
		{
			return _diffuseTexture;
		}
	}
}
