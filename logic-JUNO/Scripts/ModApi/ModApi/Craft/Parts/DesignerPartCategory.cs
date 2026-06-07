using UnityEngine;

namespace ModApi.Craft.Parts
{
	public class DesignerPartCategory : ScriptableObject
	{
		[SerializeField]
		[Tooltip("Should this category only be shown in career mode.")]
		private bool _careerModeOnly;

		[SerializeField]
		[Tooltip("The display name for the category.")]
		private string _displayName;

		[SerializeField]
		[Tooltip("The display order for the category. Categories will be sorted by display order with the lowest values displayed first.")]
		private int _displayOrder;

		[SerializeField]
		[Tooltip("The icon for the category. Typically, this should be a transparent 50x50 sprite.")]
		private Sprite _icon;

		[SerializeField]
		[Tooltip("The identifier for the category.")]
		private string _id;

		[SerializeField]
		[Tooltip("The tooltip for the category.")]
		private string _tooltip;

		public bool CareerModeOnly => _careerModeOnly;

		public string DisplayName => _displayName;

		public int DisplayOrder => _displayOrder;

		public Sprite Icon => _icon;

		public string IconPath => "Ui/Sprites/Design/IconPartCategory/" + _id;

		public string Id => _id;

		public string Tooltip => _tooltip;

		public static DesignerPartCategory Create(string id, string displayName, int displayOrder, string tooltip, Sprite icon)
		{
			DesignerPartCategory designerPartCategory = ScriptableObject.CreateInstance<DesignerPartCategory>();
			designerPartCategory.name = id;
			designerPartCategory._id = id;
			designerPartCategory._displayName = displayName;
			designerPartCategory._displayOrder = displayOrder;
			designerPartCategory._tooltip = tooltip;
			designerPartCategory._icon = icon;
			return designerPartCategory;
		}
	}
}
