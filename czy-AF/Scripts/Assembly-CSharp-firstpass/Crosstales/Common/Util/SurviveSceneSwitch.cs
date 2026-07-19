using System;
using System.Linq;
using UnityEngine;

namespace Crosstales.Common.Util
{
	[DisallowMultipleComponent]
	public class SurviveSceneSwitch : MonoBehaviour
	{
		[Tooltip("Objects which have to survive a scene switch.")]
		public GameObject[] Survivors;

		[Tooltip("Don't destroy gameobject during scene switches (default: true).")]
		public bool DontDestroy = true;

		private const float ensureParentTime = 1.5f;

		private float ensureParentTimer;

		private static SurviveSceneSwitch instance;

		private static Transform tf;

		private static bool loggedOnlyOneInstance;

		public void OnEnable()
		{
			if (instance == null)
			{
				instance = this;
				tf = base.transform;
				if (!BaseHelper.isEditorMode && DontDestroy)
				{
					UnityEngine.Object.DontDestroyOnLoad(tf.root.gameObject);
				}
			}
			else
			{
				if (BaseHelper.isEditorMode || !DontDestroy || !(instance != this))
				{
					return;
				}
				if (!loggedOnlyOneInstance)
				{
					Debug.LogWarning("Only one active instance of 'SurviveSceneSwitch' allowed in all scenes!" + Environment.NewLine + "This object and all survivors will now be destroyed.");
					loggedOnlyOneInstance = true;
				}
				foreach (GameObject item in Survivors.Where((GameObject _go) => _go != null))
				{
					UnityEngine.Object.Destroy(item);
				}
				UnityEngine.Object.Destroy(base.gameObject, 0.2f);
			}
		}

		public void Start()
		{
			ensureParentTimer = 1.5f;
		}

		public void Update()
		{
			ensureParentTimer += Time.deltaTime;
			if (Survivors == null || !(ensureParentTimer > 1.5f))
			{
				return;
			}
			ensureParentTimer = 0f;
			foreach (GameObject item in Survivors.Where((GameObject _go) => _go != null))
			{
				item.transform.SetParent(tf);
			}
		}
	}
}
