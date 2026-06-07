using System.Collections.Generic;
using Assets.Source.World.Frames;
using UnityEngine;

public class WorldOverviewGlitchedCell : WorldOverviewCell
{
	[SerializeField]
	private SpriteRenderer _glitch;

	[SerializeField]
	private SpriteRenderer _warning;

	private float _iconTimer;

	private int _iconIter;

	private float _backgroundTimer;

	private int _backgroundIter;

	private float _glitchStartTimer;

	private float _glitchEndTimer;

	private List<FramePrefabSet> _prefabs;

	protected override void Start()
	{
		base.Start();
		_prefabs = new List<FramePrefabSet>(WorldManager.Instance.OrderedFramePrefabs);
		if (base.Frame is T1GlitchedFrame)
		{
			_warning.gameObject.SetActive(value: false);
		}
	}

	protected override void Update()
	{
		base.Update();
		_backgroundTimer -= Time.deltaTime;
		if (_backgroundTimer < 0f)
		{
			_base.sprite = SeededRandom.Global.Choose(_prefabs).OverviewSprite;
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
			_icon.sprite = SeededRandom.Global.Choose(_prefabs).GetPreview().Icon;
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
				_glitch.gameObject.SetActive(value: false);
				_glitchStartTimer = SeededRandom.Global.RandomRange(0f, 3f);
			}
			return;
		}
		_glitchStartTimer -= Time.deltaTime;
		if (_glitchStartTimer < 0f)
		{
			_glitch.transform.localPosition = new Vector3(SeededRandom.Global.RandomRange(-0.5f, 0.5f), SeededRandom.Global.RandomRange(-0.5f, 0.5f), -1f);
			_glitch.color = new Color(SeededRandom.Global.RandomFloat(), SeededRandom.Global.RandomFloat(), SeededRandom.Global.RandomFloat(), 0.8f);
			_glitch.transform.localEulerAngles = new Vector3(0f, 0f, (!SeededRandom.Global.RandomBool()) ? 90 : 0);
			_glitch.gameObject.SetActive(value: true);
			_glitchEndTimer = SeededRandom.Global.RandomRange(0.05f, 0.1f);
		}
	}
}
