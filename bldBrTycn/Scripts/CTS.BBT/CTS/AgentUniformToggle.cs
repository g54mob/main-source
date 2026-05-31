using CTS.Core;
using CTS.UI;
using UnityEngine;
using UnityEngine.Localization.Components;

namespace CTS
{
	public class AgentUniformToggle : CTSBehaviour, IRepaint
	{
		[SerializeField]
		private LocalizeStringEvent _nameString;

		[Inject(false)]
		private CTSToggle _toggle;

		[InjectScope(EGetScope.Parent)]
		[Inject(false)]
		private AgentPanelUniforms _uniformsPanel;

		public CharacterSpecificClothesData ClothesData { get; private set; }

		protected override void OnAwake()
		{
			base.OnAwake();
			_toggle.onValueChanged.AddListener(OnToggleChanged);
			CharacterSpecificClothesData.ClothesChanged += OnClothesChanged;
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			Repaint();
		}

		private void OnDestroy()
		{
			CharacterSpecificClothesData.ClothesChanged -= OnClothesChanged;
		}

		public void SetData(CharacterSpecificClothesData clothesData)
		{
			if ((object)clothesData != ClothesData)
			{
				ClothesData = clothesData;
				_nameString.StringReference = clothesData.Name;
			}
		}

		private void OnClothesChanged()
		{
			Repaint();
		}

		private void OnToggleChanged(bool isOn)
		{
			if (!(_uniformsPanel.Agent == null) && isOn)
			{
				ClothesData.ChangeClothes(_uniformsPanel.Agent.AgentVisualControler);
				Repaint();
			}
		}

		public void Repaint()
		{
			if (_uniformsPanel.Agent == null)
			{
				return;
			}
			if (ClothesData.IsCurrent(_uniformsPanel.Agent.AgentVisualControler.CharacterData))
			{
				if (!_toggle.isOn)
				{
					_toggle.isOn = true;
				}
			}
			else if (_toggle.isOn)
			{
				_toggle.isOn = false;
			}
		}
	}
}
