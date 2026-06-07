using Assets.Scripts.Flight;
using Cysharp.Threading.Tasks;
using Unity.Profiling;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Mfd
{
	public class MfdScript : PartModifierScript, IRoundRobinUpdate
	{
		private static class Profile
		{
			public static readonly ProfilerMarker OnButtonPressed = new ProfilerMarker("MfdScript.OnButtonPressed");

			public static readonly ProfilerMarker OnLateUpdate = new ProfilerMarker("MfdScript.OnLateUpdate");

			public static readonly ProfilerMarker OnPreStart = new ProfilerMarker("MfdScript.OnPreStart");

			public static readonly ProfilerMarker OnRoundRobinUpdate = new ProfilerMarker("MfdScript.OnRoundRobinUpdate");
		}

		private Canvas _canvas;

		private bool _culled;

		private MfdProgram _program;

		public MfdData Data { get; set; }

		public bool IsDestroyed => base.gameObject == null;

		public MfdButtonScript OutlinedButton { get; set; }

		public string RoundRobinGroupKey => "MfdScript";

		public override void BuildPreStartInitializationPlan(PreStartInitializationPlan plan)
		{
			base.BuildPreStartInitializationPlan(plan);
			plan.Register(this, OnPreStart, PreStartInitializationFlags.FlightLocal);
		}

		public void OnButtonPressed(int buttonID, bool pressed)
		{
			using (Profile.OnButtonPressed.Auto())
			{
				_program.OnButtonPressed(buttonID, pressed);
			}
		}

		public void OnRoundRobinUpdate(bool isActiveThisFrame)
		{
			using (Profile.OnRoundRobinUpdate.Auto())
			{
				if (isActiveThisFrame && !_culled)
				{
					_program?.Update();
				}
			}
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			registrar.RegisterLateUpdate(OnLateUpdate, CraftUpdateFlags.FlightLocal);
		}

		private void OnLateUpdate(in CraftUpdateFrameData frame)
		{
			using (Profile.OnLateUpdate.Auto())
			{
				if (OutlinedButton != null)
				{
					base.PartScript.PartMaterialScript.DrawOutlineForRenderer(OutlinedButton.Renderer, outline: true, null);
				}
				if (_culled != base.PartScript.Culled)
				{
					_culled = base.PartScript.Culled;
					_canvas.gameObject.SetActive(!_culled);
				}
			}
		}

		private UniTask OnPreStart(AircraftScript craftScript, CraftLoadContext loadContext, bool async)
		{
			using (Profile.OnPreStart.Auto())
			{
				_canvas = GetComponentInChildren<Canvas>();
				_canvas.worldCamera = FlightSceneScript.Instance.CameraScript.MainCamera;
				_program = new MfdProgram(base.PartScript.Aircraft, Data.TargetingPod);
				_program.LoadXml(Game.Instance.ResourceLoader.LoadXml("Craft/Mfd/MfdProgram").Root, _canvas.GetComponent<RectTransform>());
				base.PartScript.Aircraft.RoundRobinUpdateManager.Register(this);
				return UniTask.CompletedTask;
			}
		}
	}
}
