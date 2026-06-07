using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Gh.Tk.Story.Structure;
using I18n;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs
{
	public class TavernLayoutSelector3DUIView : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProI18n _layoutName;

		[SerializeField]
		private BaseInteractable3DUIView _previousButton;

		[SerializeField]
		private BaseInteractable3DUIView _nextButton;

		private List<FreeplayStartNode> _freeplayScenarios;

		[SerializeField]
		private SpriteRenderer _layoutImage;

		public event EventHandler ScenarioChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public void Init(ScenarioSettings settings)
		{
		}

		private void SetCurrentLayout(ScenarioSettings settings)
		{
		}

		private void SetLayoutImage(ScenarioSettings settings)
		{
		}
	}
}
