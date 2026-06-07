using System.Collections.Generic;
using System.Reflection;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Styles;

namespace ModApi.Design.PartProperties
{
	public interface IDesignerPartPropertiesDesignerInterface
	{
		PartModifierData PartModifierData { get; }

		string GetHeaderLabel();

		string GetValueLabel(FieldInfo field, object value);

		bool IsVisible(FieldInfo field, bool showHiddenFields);

		void OnActivated(IDesignerPartProperties partPropertiesScript);

		void OnDeactivated(IDesignerPartProperties partPropertiesScript);

		void OnPartMaterialsChanged();

		void OnPartStyleChanged(IPartStyle previousStyle, IPartStyle newStyle);

		void OnPartTextureStyleChanged(IPartTextureStyle previousStyle, IPartTextureStyle newStyle);

		void OnPropertyActivated(IConfigurableProperty property);

		void OnPropertyChanged(FieldInfo field, object newVal, object oldVal);

		void OnRefreshUI();

		void OnUpdate();

		void SetVisible(FieldInfo field, bool visible);

		void UpdateSpinnerValues(FieldInfo field, List<string> currentValues);
	}
}
