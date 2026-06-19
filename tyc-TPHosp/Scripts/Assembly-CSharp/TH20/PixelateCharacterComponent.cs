using System;
using UnityEngine;

namespace TH20
{
	public class PixelateCharacterComponent : EntityTickComponent
	{
		private Character _character;

		public float _scaleX = 1f;

		public float _scaleY = 1f;

		public GameObject _pixelatedPrefab;

		[DontSave]
		private GameObject _pixelatedUI;

		[DontSave]
		private RectTransform _pixelatedPanel;

		[DontSave]
		private InWorldHUDElement _hudElement;

		protected override Type ValidEntityType()
		{
			return typeof(Character);
		}

		internal override void InitializeComponent()
		{
			base.InitializeComponent();
			_character = GetOwner<Character>();
			CreateUI();
		}

		internal override void RestoreComponentFromSave()
		{
			base.RestoreComponentFromSave();
			CreateUI();
		}

		private void CreateUI()
		{
			GameObject gameObject = ((_pixelatedPrefab != null) ? _pixelatedPrefab : _character.Definition.PixelatedPrefab);
			if (gameObject != null)
			{
				_pixelatedUI = UnityEngine.Object.Instantiate(gameObject);
				_pixelatedPanel = _pixelatedUI.transform.GetChild(0).GetComponent<RectTransform>();
				_hudElement = _pixelatedUI.GetComponent<InWorldHUDElement>();
				_character.Level.HUD.AddElement(_hudElement);
			}
		}

		public override void Destroy()
		{
			if (_pixelatedUI != null)
			{
				_character.Level.HUD.RemoveElement(_hudElement);
				UnityEngine.Object.Destroy(_pixelatedUI);
			}
			base.Destroy();
		}

		public override void Tick()
		{
			base.Tick();
			if (_pixelatedUI != null)
			{
				GameObject gameObject = _character.GameObject;
				Renderer componentInChildren = gameObject.GetComponentInChildren<Renderer>();
				if (componentInChildren == null || !componentInChildren.isVisible)
				{
					GameObjectUtils.SetActive(_pixelatedUI, isActive: false);
					return;
				}
				Bounds bounds = gameObject.GetComponent<BoxCollider>().bounds;
				Rect screenRect = bounds.GetScreenRect();
				GameObjectUtils.SetActive(_pixelatedUI, isActive: true);
				_hudElement.Position = bounds.center;
				_pixelatedPanel.sizeDelta = new Vector2(screenRect.width * _scaleX, screenRect.height * _scaleY);
			}
		}
	}
}
