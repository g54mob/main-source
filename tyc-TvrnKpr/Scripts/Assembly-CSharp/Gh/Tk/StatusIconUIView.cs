using System;
using System.Collections.Generic;
using Gh.Tk.UI;
using UnityEngine;

namespace Gh.Tk
{
	public class StatusIconUIView : MonoBehaviour
	{
		[Serializable]
		public class IconBackerStyle
		{
			public string id;

			public float wiggleAnimationSpeed;

			[DropDownChoice(new string[] { "thought", "error", "talking" })]
			public string backer;

			public bool useQuestioningEffect;
		}

		private const string iconPrefabSuffix = "_StatusIcon";

		private const string backerPrefabSuffix = "_StatusIconBacker";

		public const string NullIconId = "none";

		private static Dictionary<string, GameObject> _icons3DPrefabCache;

		private static PrefabObjectPool _pool;

		[SerializeField]
		private SpriteRenderer _iconSpriteRenderer;

		private Dictionary<string, GameObject> _backers;

		[SerializeField]
		private GameObject _questioningEffect;

		[SerializeField]
		private IconAnimation _wiggleAnimation;

		private string _currentIcon;

		private string _currentBacker;

		public List<GameObject> backerPrefabs;

		public List<IconBackerStyle> backerStyles;

		[SerializeField]
		private Transform _icon2DSocket;

		[SerializeField]
		private Transform _icon3DSocket;

		private Dictionary<string, GameObject> _icons3D;

		[SerializeField]
		private Transform _priorityIcon;

		[SerializeField]
		private GameObject _happinessStatusIcon;

		protected Transform _patienceMeterTransform;

		protected Countdown3DUIView _patienceMeter;

		protected Transform _storyMeterTransform;

		protected Countdown3DUIView _storyTimeoutCountdown;

		public string CurrentIcon => null;

		public string CurrentStatusBacker => null;

		public bool IsPositionDirty { get; set; }

		public static StatusIconUIView GetPooledInstance()
		{
			return null;
		}

		public void Kill()
		{
		}

		public void Init()
		{
		}

		public Countdown3DUIView GetPatienceMeterCountdown()
		{
			return null;
		}

		public Countdown3DUIView GetStoryMeterCountdown()
		{
			return null;
		}

		public void SetBacker(string backerId)
		{
		}

		public void SetBacker(IconBackerStyle backerStyle)
		{
		}

		public bool IsSet()
		{
			return false;
		}

		public void SetIcon(string icon, string backer)
		{
		}

		private GameObject Get3DIcon(string iconId)
		{
			return null;
		}

		public void SetLocalPosition(Vector3 localPos)
		{
		}

		public void Clear()
		{
		}

		public void ShowPriorityIcon(bool show)
		{
		}
	}
}
