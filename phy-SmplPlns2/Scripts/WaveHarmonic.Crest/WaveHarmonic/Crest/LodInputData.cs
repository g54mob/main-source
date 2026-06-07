using System;
using UnityEngine;
using UnityEngine.Rendering;
using WaveHarmonic.Crest.Internal;

namespace WaveHarmonic.Crest
{
	[Serializable]
	public abstract class LodInputData : Versioned
	{
		[SerializeField]
		[HideInInspector]
		internal LodInput _Input;

		private protected Rect _Rect;

		private protected Bounds _Bounds;

		private protected bool _RecalculateRect = true;

		private protected bool _RecalculateBounds = true;

		internal abstract bool IsEnabled { get; }

		internal virtual bool HasHeightRange => true;

		internal Rect Rect
		{
			get
			{
				if (_RecalculateRect)
				{
					RecalculateRect();
					_RecalculateRect = false;
				}
				return _Rect;
			}
		}

		internal Bounds Bounds
		{
			get
			{
				if (_RecalculateBounds)
				{
					RecalculateBounds();
					_RecalculateBounds = false;
				}
				return _Bounds;
			}
		}

		internal Vector2 HeightRange
		{
			get
			{
				if (!HasHeightRange)
				{
					return Vector2.zero;
				}
				Bounds bounds = Bounds;
				return new Vector2(bounds.min.y, bounds.max.y);
			}
		}

		internal abstract void OnEnable();

		internal abstract void OnDisable();

		internal abstract void Draw(Lod lod, Component component, CommandBuffer buffer, RenderTargetIdentifier target, int slice);

		internal abstract void RecalculateRect();

		internal abstract void RecalculateBounds();

		private protected void RecalculateCulling()
		{
			_RecalculateRect = (_RecalculateBounds = true);
		}

		internal virtual void OnUpdate()
		{
			if (_Input.transform.hasChanged)
			{
				RecalculateCulling();
			}
		}

		internal virtual void OnLateUpdate()
		{
		}
	}
}
