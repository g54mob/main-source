using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace Timberborn.CoreUI
{
	[UxmlElement]
	public class ProgressBar : VisualElement
	{
		[Serializable]
		public new class UxmlSerializedData : VisualElement.UxmlSerializedData
		{
			public override object CreateInstance()
			{
				return new ProgressBar();
			}
		}

		private readonly SimpleProgressBar _simpleProgressBar;

		public override VisualElement contentContainer { get; }

		public ProgressBar()
		{
			Resources.Load<VisualTreeAsset>("UI/Views/Core/ProgressBar").CloneTree(this);
			_simpleProgressBar = this.Q<SimpleProgressBar>("Progress");
			contentContainer = this.Q<VisualElement>("ContentContainer");
		}

		public void SetProgress(float progress)
		{
			_simpleProgressBar.SetProgress(progress);
		}
	}
}
