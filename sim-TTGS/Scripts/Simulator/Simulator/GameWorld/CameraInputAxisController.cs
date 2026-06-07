using System;
using Dhs5.Utility.Settings;
using Dhs5.Utility.Updates;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Simulator.GameWorld
{
	public class CameraInputAxisController : InputAxisControllerBase<CameraInputAxisController.Reader>
	{
		[Serializable]
		public sealed class Reader : IInputAxisReader
		{
			[SerializeField]
			private InputActionReference m_inputAction;

			[SerializeField]
			private EPOVCameraInputProvider m_provider;

			public float GetValue(UnityEngine.Object context, IInputAxisOwner.AxisDescriptor.Hints hint)
			{
				if (Updater.Frame > 5 && m_inputAction != null && CameraManager.UpdateFPSCameras)
				{
					float num = (float)GameplayApplicationOptions.Sensitivity * CustomSettings<GameplayApplicationOptions>.I.GetSensitivityByProvider(m_provider);
					float num2;
					switch (hint)
					{
					case IInputAxisOwner.AxisDescriptor.Hints.X:
						num2 = m_inputAction.action.ReadValue<Vector2>().x * num;
						if ((bool)GameplayApplicationOptions.CameraInvertYaw)
						{
							num2 = 0f - num2;
						}
						break;
					case IInputAxisOwner.AxisDescriptor.Hints.Y:
						num2 = m_inputAction.action.ReadValue<Vector2>().y * num;
						if (!GameplayApplicationOptions.CameraInvertPitch)
						{
							num2 = 0f - num2;
						}
						break;
					case IInputAxisOwner.AxisDescriptor.Hints.Default:
						num2 = m_inputAction.action.ReadValue<float>() * num;
						break;
					default:
						throw new ArgumentOutOfRangeException("hint", hint, null);
					}
					return num2;
				}
				return 0f;
			}
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			if (Application.isPlaying)
			{
				Updater.RegisterChannelCallback(register: true, EUpdateChannel.GAME_PLAYING, OnUpdate);
			}
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			if (Application.isPlaying)
			{
				Updater.RegisterChannelCallback(register: false, EUpdateChannel.GAME_PLAYING, OnUpdate);
			}
		}

		private void OnUpdate(float deltaTime)
		{
			if (Application.isPlaying)
			{
				UpdateControllers(deltaTime);
			}
		}

		protected override void Reset()
		{
			base.Reset();
			ScanRecursively = false;
		}

		protected override void InitializeControllerDefaultsForAxis(in IInputAxisOwner.AxisDescriptor axis, Controller controller)
		{
			base.InitializeControllerDefaultsForAxis(in axis, controller);
			switch (axis.Hint)
			{
			case IInputAxisOwner.AxisDescriptor.Hints.X:
				controller.Driver = new DefaultInputAxisDriver
				{
					AccelTime = 0.1f,
					DecelTime = 0.1f
				};
				break;
			case IInputAxisOwner.AxisDescriptor.Hints.Y:
				controller.Driver = new DefaultInputAxisDriver
				{
					AccelTime = 0.1f,
					DecelTime = 0.1f
				};
				break;
			}
		}
	}
}
