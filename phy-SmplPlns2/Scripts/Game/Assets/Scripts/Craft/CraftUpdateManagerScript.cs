using System;
using System.Collections.Generic;
using Assets.Scripts.Flight.Demo;
using Jundroo.Common.Platform;
using Unity.Profiling;
using UnityEngine;

namespace Assets.Scripts.Craft
{
	public class CraftUpdateManagerScript : MonoBehaviour
	{
		private static class Profile
		{
			public static readonly ProfilerMarker FixedUpdate = new ProfilerMarker("CraftUpdateManagerScript.FixedUpdate");

			public static readonly ProfilerMarker FixedUpdateBodies = new ProfilerMarker(CraftUpdateScriptPrefix + "OnFixedUpdateBodyScripts");

			public static readonly ProfilerMarker FixedUpdateCraft = new ProfilerMarker(CraftUpdateScriptPrefix + "OnFixedUpdateCraftScripts");

			public static readonly ProfilerMarker FixedUpdateModifiers = new ProfilerMarker(CraftUpdateScriptPrefix + "OnFixedUpdateModifierScripts");

			public static readonly ProfilerMarker FixedUpdateParts = new ProfilerMarker(CraftUpdateScriptPrefix + "OnFixedUpdatePartScripts");

			public static readonly ProfilerMarker FixedUpdateStart = new ProfilerMarker(CraftUpdateScriptPrefix + "OnFixedUpdateStart");

			public static readonly ProfilerMarker LateUpdate = new ProfilerMarker("CraftUpdateManagerScript.LateUpdate");

			public static readonly ProfilerMarker LateUpdateBodies = new ProfilerMarker(CraftUpdateScriptPrefix + "OnLateUpdateBodyScripts");

			public static readonly ProfilerMarker LateUpdateCraft = new ProfilerMarker(CraftUpdateScriptPrefix + "OnLateUpdateCraftScripts");

			public static readonly ProfilerMarker LateUpdateModifiers = new ProfilerMarker(CraftUpdateScriptPrefix + "OnLateUpdateModifierScripts");

			public static readonly ProfilerMarker LateUpdatePartMaterials = new ProfilerMarker(CraftUpdateScriptPrefix + "OnLateUpdatePartMaterialScripts");

			public static readonly ProfilerMarker LateUpdateParts = new ProfilerMarker(CraftUpdateScriptPrefix + "OnLateUpdatePartScripts");

			public static readonly ProfilerMarker LateUpdateStart = new ProfilerMarker(CraftUpdateScriptPrefix + "OnLateUpdateStart");

			public static readonly ProfilerMarker Update = new ProfilerMarker("CraftUpdateManagerScript.Update");

			public static readonly ProfilerMarker UpdateBodies = new ProfilerMarker(CraftUpdateScriptPrefix + "OnUpdateBodyScripts");

			public static readonly ProfilerMarker UpdateCraft = new ProfilerMarker(CraftUpdateScriptPrefix + "OnUpdateCraftScripts");

			public static readonly ProfilerMarker UpdateModifiers = new ProfilerMarker(CraftUpdateScriptPrefix + "OnUpdateModifierScripts");

			public static readonly ProfilerMarker UpdateParts = new ProfilerMarker(CraftUpdateScriptPrefix + "OnUpdatePartScripts");

			public static readonly ProfilerMarker UpdateStart = new ProfilerMarker(CraftUpdateScriptPrefix + "OnUpdateStart");

			private static readonly string CraftUpdateScriptPrefix = string.Empty;
		}

		private class UpdateAction
		{
			private Action<CraftUpdateScript> Action { get; }

			private ProfilerMarker ProfilerMarker { get; }

			public UpdateAction(Action<CraftUpdateScript> action, ProfilerMarker profilerMarker)
			{
				Action = action;
				ProfilerMarker = profilerMarker;
			}

			public void Execute(List<CraftUpdateScript> scripts)
			{
				foreach (CraftUpdateScript script in scripts)
				{
					try
					{
						Action(script);
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
					}
					finally
					{
					}
				}
			}
		}

		[SerializeField]
		private List<CraftUpdateScript> _craftUpdateScripts;

		private DemoRestrictedAirspace _demoRestrictedAirspace;

		private UpdateAction[] _fixedUpdateActions;

		private UpdateAction[] _lateUpdateActions;

		private UpdateAction[] _updateActions;

		public static CraftUpdateManagerScript Create(GameObject parent)
		{
			CraftUpdateManagerScript craftUpdateManagerScript = new GameObject("CraftUpdateManager").AddComponent<CraftUpdateManagerScript>();
			craftUpdateManagerScript.transform.SetParent(parent.transform);
			try
			{
				craftUpdateManagerScript.Initialize();
			}
			catch (Exception exception)
			{
				Debug.LogError("An error occurred initializing the craft update manager");
				Debug.LogException(exception);
			}
			return craftUpdateManagerScript;
		}

		public void OnSceneTransitionCleanup()
		{
			if (_craftUpdateScripts.Count > 0)
			{
				Debug.LogError(string.Format("{0} craft update script{1} ", _craftUpdateScripts.Count, (_craftUpdateScripts.Count > 1) ? "s" : string.Empty) + "is still being tracked by the craft update manager during a scene transition. This is likely a leak and an attempt will be made to clean up");
				foreach (CraftUpdateScript craftUpdateScript in _craftUpdateScripts)
				{
					if (craftUpdateScript != null && craftUpdateScript.gameObject != null)
					{
						UnityEngine.Object.Destroy(craftUpdateScript.gameObject);
					}
				}
				_craftUpdateScripts.Clear();
			}
			foreach (CraftUpdateScript craftUpdateScript2 in _craftUpdateScripts)
			{
				craftUpdateScript2.OnSceneTransitionCleanup();
			}
		}

		public void Register(CraftUpdateScript craftUpdateScript)
		{
			_craftUpdateScripts.Add(craftUpdateScript);
		}

		public void Unregister(CraftUpdateScript craftUpdateScript)
		{
			_craftUpdateScripts.Remove(craftUpdateScript);
		}

		protected virtual void FixedUpdate()
		{
			UpdateAction[] fixedUpdateActions = _fixedUpdateActions;
			for (int i = 0; i < fixedUpdateActions.Length; i++)
			{
				fixedUpdateActions[i].Execute(_craftUpdateScripts);
			}
			_demoRestrictedAirspace?.OnFixedUpdate();
		}

		protected virtual void LateUpdate()
		{
			UpdateAction[] lateUpdateActions = _lateUpdateActions;
			for (int i = 0; i < lateUpdateActions.Length; i++)
			{
				lateUpdateActions[i].Execute(_craftUpdateScripts);
			}
		}

		protected virtual void OnDrawGizmosSelected()
		{
			_demoRestrictedAirspace?.OnDrawGizmosSelected();
		}

		protected virtual void Update()
		{
			UpdateAction[] updateActions = _updateActions;
			for (int i = 0; i < updateActions.Length; i++)
			{
				updateActions[i].Execute(_craftUpdateScripts);
			}
			_demoRestrictedAirspace?.OnUpdate();
		}

		private void Initialize()
		{
			_craftUpdateScripts = new List<CraftUpdateScript>();
			_updateActions = new UpdateAction[5]
			{
				new UpdateAction(delegate(CraftUpdateScript x)
				{
					x.OnUpdateStart();
				}, Profile.UpdateStart),
				new UpdateAction(delegate(CraftUpdateScript x)
				{
					x.OnUpdateCraftScripts();
				}, Profile.UpdateCraft),
				new UpdateAction(delegate(CraftUpdateScript x)
				{
					x.OnUpdateBodyScripts();
				}, Profile.UpdateBodies),
				new UpdateAction(delegate(CraftUpdateScript x)
				{
					x.OnUpdatePartScripts();
				}, Profile.UpdateParts),
				new UpdateAction(delegate(CraftUpdateScript x)
				{
					x.OnUpdateModifierScripts();
				}, Profile.UpdateModifiers)
			};
			_lateUpdateActions = new UpdateAction[6]
			{
				new UpdateAction(delegate(CraftUpdateScript x)
				{
					x.OnLateUpdateStart();
				}, Profile.LateUpdateStart),
				new UpdateAction(delegate(CraftUpdateScript x)
				{
					x.OnLateUpdateCraftScripts();
				}, Profile.LateUpdateCraft),
				new UpdateAction(delegate(CraftUpdateScript x)
				{
					x.OnLateUpdateBodyScripts();
				}, Profile.LateUpdateBodies),
				new UpdateAction(delegate(CraftUpdateScript x)
				{
					x.OnLateUpdatePartScripts();
				}, Profile.LateUpdateParts),
				new UpdateAction(delegate(CraftUpdateScript x)
				{
					x.OnLateUpdatePartMaterialScripts();
				}, Profile.LateUpdatePartMaterials),
				new UpdateAction(delegate(CraftUpdateScript x)
				{
					x.OnLateUpdateModifierScripts();
				}, Profile.LateUpdateModifiers)
			};
			_fixedUpdateActions = new UpdateAction[5]
			{
				new UpdateAction(delegate(CraftUpdateScript x)
				{
					x.OnFixedUpdateStart();
				}, Profile.FixedUpdateStart),
				new UpdateAction(delegate(CraftUpdateScript x)
				{
					x.OnFixedUpdateCraftScripts();
				}, Profile.FixedUpdateCraft),
				new UpdateAction(delegate(CraftUpdateScript x)
				{
					x.OnFixedUpdateBodyScripts();
				}, Profile.FixedUpdateBodies),
				new UpdateAction(delegate(CraftUpdateScript x)
				{
					x.OnFixedUpdatePartScripts();
				}, Profile.FixedUpdateParts),
				new UpdateAction(delegate(CraftUpdateScript x)
				{
					x.OnFixedUpdateModifierScripts();
				}, Profile.FixedUpdateModifiers)
			};
			_demoRestrictedAirspace = (Device.IsDemoBuild ? new DemoRestrictedAirspace() : null);
		}
	}
}
