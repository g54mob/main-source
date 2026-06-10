using UnityEngine;

namespace FIMSpace.FOptimizing
{
	public interface ILODInstance
	{
		int Index { get; set; }

		string Name { get; set; }

		bool CustomEditor { get; }

		bool Disable { get; set; }

		bool DrawDisableOption { get; }

		bool SupportingTransitions { get; }

		bool DrawLowererSlider { get; }

		float QualityLowerer { get; set; }

		string HeaderText { get; }

		float ToCullDelay { get; }

		bool SupportVersions { get; }

		int DrawingVersion { get; set; }

		bool LockSettings { get; set; }

		Texture Icon { get; }

		void SetSameValuesAsComponent(Component component);

		void ApplySettingsToTheComponent(Component component, ILODInstance initialSettingsReference);

		void AssignAutoSettingsAsForLODLevel(int lodIndex, int lodCount, Component source);

		void AssignSettingsAsForCulled(Component component);

		void AssignSettingsAsForNearest(Component component);

		void AssignSettingsAsForHidden(Component component);

		ILODInstance GetCopy();

		void InterpolateBetween(ILODInstance lodA, ILODInstance lodB, float transitionToB);
	}
}
