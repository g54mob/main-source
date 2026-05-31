using System.Collections.Generic;
using UnityEngine;

public class AnimationSprite : MonoBehaviour
{
	public bool NullOnEmpty;

	public List<AnimationGroup> Animations = new List<AnimationGroup>();

	private Sprite _originalSprite;

	private AnimationGroup _currentAnim;

	private SpriteRenderer _renderer;

	private AnimationGroup _previousAnim;

	private void Start()
	{
		ResetOriginalSprite();
		if (_currentAnim == null)
		{
			StartMainAnimation();
		}
	}

	public void ResetOriginalSprite()
	{
		_renderer = GetComponent<SpriteRenderer>();
		_originalSprite = _renderer.sprite;
		if (NullOnEmpty)
		{
			_originalSprite = null;
		}
		_renderer.sprite = _originalSprite;
	}

	private void Update()
	{
		if (_currentAnim != null)
		{
			_currentAnim.UpdateFrame();
			_renderer.sprite = _currentAnim.GetSprite();
			if (_renderer.sprite == null)
			{
				_renderer.sprite = _originalSprite;
			}
			if (!_currentAnim.IsRunning())
			{
				StartMainAnimation();
			}
		}
		else
		{
			_renderer.sprite = _originalSprite;
		}
	}

	public bool IsPlaying()
	{
		return _currentAnim != null;
	}

	public void Play(string name)
	{
		if (name == "")
		{
			_previousAnim = null;
			_currentAnim = null;
			StartMainAnimation();
			return;
		}
		foreach (AnimationGroup animation in Animations)
		{
			if (animation.Name == name)
			{
				if (_currentAnim != animation)
				{
					_previousAnim = null;
					_currentAnim = animation;
					_currentAnim.Reset();
				}
				break;
			}
		}
	}

	public void PlayAndReturn(string name)
	{
		if (name == "")
		{
			StartMainAnimation();
			return;
		}
		foreach (AnimationGroup animation in Animations)
		{
			if (animation.Name == name)
			{
				if (_currentAnim != animation)
				{
					_previousAnim = _currentAnim;
					_currentAnim = animation;
					_currentAnim.Reset();
				}
				break;
			}
		}
	}

	public void SetAsFirstFrame()
	{
		if (_currentAnim != null && _currentAnim.Sprite.Count > 0)
		{
			_originalSprite = _currentAnim.Sprite[0];
			_renderer.sprite = _originalSprite;
		}
	}

	private void StartMainAnimation()
	{
		if (_previousAnim != null)
		{
			_currentAnim = _previousAnim;
			_currentAnim.Reset();
			return;
		}
		_previousAnim = null;
		_currentAnim = null;
		foreach (AnimationGroup animation in Animations)
		{
			if (animation.IsDefault)
			{
				if (_currentAnim != animation)
				{
					_currentAnim = animation;
					_currentAnim.Reset();
				}
				break;
			}
		}
	}
}
