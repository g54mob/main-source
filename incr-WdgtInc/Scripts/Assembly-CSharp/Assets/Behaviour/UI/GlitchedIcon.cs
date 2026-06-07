using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Behaviour.UI
{
	public class GlitchedIcon : MonoBehaviour
	{
		[SerializeField]
		private bool _autoSet = true;

		[SerializeField]
		private bool _isWidget;

		[SerializeField]
		private Image _backgroundImage;

		[SerializeField]
		private Image _iconImage;

		[SerializeField]
		private SpriteRenderer _backgroundSprite;

		[SerializeField]
		private SpriteRenderer _iconSprite;

		private float _iconTimer;

		private int _iconIter;

		private float _backgroundTimer;

		private int _backgroundIter;

		private float _glitchStartTimer;

		private float _glitchEndTimer;

		private List<FramePrefabSet> _prefabs;

		private void Start()
		{
			_prefabs = new List<FramePrefabSet>(WorldManager.Instance.OrderedFramePrefabs);
			_iconIter = SeededRandom.Global.RandomRange(3, 8);
			_backgroundIter = SeededRandom.Global.RandomRange(3, 8);
			if (_isWidget)
			{
				for (int i = 0; i < _prefabs.Count; i++)
				{
					if (!_prefabs[i].GetPreview().GetType().Name.EndsWith("Widget"))
					{
						_prefabs.RemoveAt(i);
						i--;
					}
				}
			}
			if (!_autoSet)
			{
				return;
			}
			if (!_backgroundImage)
			{
				_backgroundImage = GetComponent<Image>();
			}
			if (!_backgroundSprite)
			{
				_backgroundSprite = GetComponent<SpriteRenderer>();
			}
			if (!_iconImage)
			{
				foreach (Transform item in base.transform)
				{
					_iconImage = _iconImage ?? item.GetComponent<Image>();
				}
			}
			if ((bool)_iconSprite)
			{
				return;
			}
			foreach (Transform item2 in base.transform)
			{
				_iconSprite = _iconSprite ?? item2.GetComponent<SpriteRenderer>();
			}
		}

		private void Update()
		{
			_backgroundTimer -= Time.deltaTime;
			if (_backgroundTimer < 0f)
			{
				Sprite overviewSprite = SeededRandom.Global.Choose(_prefabs).OverviewSprite;
				if ((bool)_backgroundImage)
				{
					_backgroundImage.sprite = overviewSprite;
				}
				if ((bool)_backgroundSprite)
				{
					_backgroundSprite.sprite = overviewSprite;
				}
				if (_backgroundIter > 0)
				{
					_backgroundTimer = SeededRandom.Global.RandomRange(0.1f, 0.2f);
					_backgroundIter--;
				}
				else
				{
					_backgroundTimer = SeededRandom.Global.RandomRange(2f, 4f);
					_backgroundIter = SeededRandom.Global.RandomRange(3, 8);
				}
			}
			_iconTimer -= Time.deltaTime;
			if (_iconTimer < 0f)
			{
				Sprite icon = SeededRandom.Global.Choose(_prefabs).GetPreview().Icon;
				if ((bool)_iconImage)
				{
					_iconImage.sprite = icon;
				}
				if ((bool)_iconSprite)
				{
					_iconSprite.sprite = icon;
				}
				if (_iconIter > 0)
				{
					_iconTimer = SeededRandom.Global.RandomRange(0.1f, 0.2f);
					_iconIter--;
				}
				else
				{
					_iconTimer = SeededRandom.Global.RandomRange(2f, 4f);
					_iconIter = SeededRandom.Global.RandomRange(3, 8);
				}
			}
			if (_glitchEndTimer > 0f)
			{
				_glitchEndTimer -= Time.deltaTime;
				if (_glitchEndTimer <= 0f)
				{
					_glitchStartTimer = SeededRandom.Global.RandomRange(0f, 3f);
				}
			}
			else
			{
				_glitchStartTimer -= Time.deltaTime;
				if (_glitchStartTimer < 0f)
				{
					_glitchEndTimer = SeededRandom.Global.RandomRange(0.05f, 0.1f);
				}
			}
		}

		public void Setup(Image background, Image icon)
		{
			_backgroundImage = background;
			_iconImage = icon;
			_autoSet = false;
		}

		public void SetWidget(bool v)
		{
			_isWidget = v;
		}
	}
}
