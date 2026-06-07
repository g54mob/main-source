using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;

namespace VampireSurvivors.Graphics
{
	public class SpriteTrail : GameMonoBehaviour
	{
		[SerializeField]
		public SpriteRenderer _MainSprite;

		[SerializeField]
		private int _MaxHistory;

		[SerializeField]
		private List<string> _Tints;

		[SerializeField]
		public float _DefaultGhostAlpha;

		[SerializeField]
		public float _AlphaDecayPerGhost;

		[SerializeField]
		private Vector2 _ScaleModifier;

		[SerializeField]
		private Material _MaterialOverride;

		[SerializeField]
		[Tooltip("Will make all ghosts use the same latest angle")]
		private bool _MatchTargetAngle;

		[SerializeField]
		private bool _UsePauseSystem;

		[SerializeField]
		private bool _AutoUpdateDepth;

		public static GameObject TrailContainer;

		private List<Vector3> _positionHistory;

		private List<Vector3> _angleHistory;

		private List<Vector3> _scaleHistory;

		private List<SpriteRenderer> _ghosts;

		private int _historyIndex;

		private bool _skipOne;

		private int _knownHistory;

		private static int _fps;

		private static double _frameTime;

		private double _frameTimeMS;

		private double _elapsed;

		private static ProfilerMarker _markerOnEnableBase;

		private static ProfilerMarker _markerOnEnableGhosts;

		private static ProfilerMarker _markerOnDisableBase;

		private static ProfilerMarker _markerOnDisableGhosts;

		public bool AutoUpdateDepth
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		protected override void OnEnable()
		{
		}

		protected override void OnDisable()
		{
		}

		protected override void OnDestroy()
		{
		}

		public void Start()
		{
		}

		private void ResetHistory()
		{
		}

		public int GetMaxHistory()
		{
			return 0;
		}

		public void SetMaxHistory(int max)
		{
		}

		public void SetMaskInteraction(SpriteMaskInteraction interaction)
		{
		}

		public void InitialiseGhosts(bool expandExisting = false)
		{
		}

		public void ResetGhostValues()
		{
		}

		private void LateUpdate()
		{
		}

		public void Reset()
		{
		}

		public SpriteTrail SetSprite(int index, Sprite s)
		{
			return null;
		}

		public SpriteTrail SetTint(int index, Color c)
		{
			return null;
		}

		public SpriteTrail SetAlpha(int index, float a)
		{
			return null;
		}

		public SpriteTrail SetTint(int index, string c)
		{
			return null;
		}

		public Vector3 GetPosition(int index)
		{
			return default(Vector3);
		}

		public SpriteTrail SetPosition(int index, Vector3 position)
		{
			return null;
		}

		public SpriteTrail SetColors(List<string> colors)
		{
			return null;
		}

		public SpriteTrail SetAlphas(List<float> alphas)
		{
			return null;
		}

		public SpriteTrail setVisible(bool b)
		{
			return null;
		}

		public void UpdateDepth()
		{
		}

		public SpriteRenderer GetTrailSprite(int index)
		{
			return null;
		}

		public int GetGhostCount()
		{
			return 0;
		}

		private int GetHistoryIndex(int index)
		{
			return 0;
		}
	}
}
