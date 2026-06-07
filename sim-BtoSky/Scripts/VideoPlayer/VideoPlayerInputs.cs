using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class VideoPlayerInputs : IInputActionCollection2, IInputActionCollection, IEnumerable<InputAction>, IEnumerable, IDisposable
{
	public struct VideoPlayerControlActions
	{
		private VideoPlayerInputs m_Wrapper;

		public InputAction PlayPause => m_Wrapper.m_VideoPlayerControl_PlayPause;

		public InputAction NextFrame => m_Wrapper.m_VideoPlayerControl_NextFrame;

		public InputAction PreviousFrame => m_Wrapper.m_VideoPlayerControl_PreviousFrame;

		public bool enabled => Get().enabled;

		public VideoPlayerControlActions(VideoPlayerInputs wrapper)
		{
			m_Wrapper = wrapper;
		}

		public InputActionMap Get()
		{
			return m_Wrapper.m_VideoPlayerControl;
		}

		public void Enable()
		{
			Get().Enable();
		}

		public void Disable()
		{
			Get().Disable();
		}

		public static implicit operator InputActionMap(VideoPlayerControlActions set)
		{
			return set.Get();
		}

		public void AddCallbacks(IVideoPlayerControlActions instance)
		{
			if (instance != null && !m_Wrapper.m_VideoPlayerControlActionsCallbackInterfaces.Contains(instance))
			{
				m_Wrapper.m_VideoPlayerControlActionsCallbackInterfaces.Add(instance);
				PlayPause.started += instance.OnPlayPause;
				PlayPause.performed += instance.OnPlayPause;
				PlayPause.canceled += instance.OnPlayPause;
				NextFrame.started += instance.OnNextFrame;
				NextFrame.performed += instance.OnNextFrame;
				NextFrame.canceled += instance.OnNextFrame;
				PreviousFrame.started += instance.OnPreviousFrame;
				PreviousFrame.performed += instance.OnPreviousFrame;
				PreviousFrame.canceled += instance.OnPreviousFrame;
			}
		}

		private void UnregisterCallbacks(IVideoPlayerControlActions instance)
		{
			PlayPause.started -= instance.OnPlayPause;
			PlayPause.performed -= instance.OnPlayPause;
			PlayPause.canceled -= instance.OnPlayPause;
			NextFrame.started -= instance.OnNextFrame;
			NextFrame.performed -= instance.OnNextFrame;
			NextFrame.canceled -= instance.OnNextFrame;
			PreviousFrame.started -= instance.OnPreviousFrame;
			PreviousFrame.performed -= instance.OnPreviousFrame;
			PreviousFrame.canceled -= instance.OnPreviousFrame;
		}

		public void RemoveCallbacks(IVideoPlayerControlActions instance)
		{
			if (m_Wrapper.m_VideoPlayerControlActionsCallbackInterfaces.Remove(instance))
			{
				UnregisterCallbacks(instance);
			}
		}

		public void SetCallbacks(IVideoPlayerControlActions instance)
		{
			foreach (IVideoPlayerControlActions videoPlayerControlActionsCallbackInterface in m_Wrapper.m_VideoPlayerControlActionsCallbackInterfaces)
			{
				UnregisterCallbacks(videoPlayerControlActionsCallbackInterface);
			}
			m_Wrapper.m_VideoPlayerControlActionsCallbackInterfaces.Clear();
			AddCallbacks(instance);
		}
	}

	public interface IVideoPlayerControlActions
	{
		void OnPlayPause(InputAction.CallbackContext context);

		void OnNextFrame(InputAction.CallbackContext context);

		void OnPreviousFrame(InputAction.CallbackContext context);
	}

	private readonly InputActionMap m_VideoPlayerControl;

	private List<IVideoPlayerControlActions> m_VideoPlayerControlActionsCallbackInterfaces = new List<IVideoPlayerControlActions>();

	private readonly InputAction m_VideoPlayerControl_PlayPause;

	private readonly InputAction m_VideoPlayerControl_NextFrame;

	private readonly InputAction m_VideoPlayerControl_PreviousFrame;

	public InputActionAsset asset { get; }

	public InputBinding? bindingMask
	{
		get
		{
			return asset.bindingMask;
		}
		set
		{
			asset.bindingMask = value;
		}
	}

	public ReadOnlyArray<InputDevice>? devices
	{
		get
		{
			return asset.devices;
		}
		set
		{
			asset.devices = value;
		}
	}

	public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

	public IEnumerable<InputBinding> bindings => asset.bindings;

	public VideoPlayerControlActions VideoPlayerControl => new VideoPlayerControlActions(this);

	public VideoPlayerInputs()
	{
		asset = InputActionAsset.FromJson("{\n    \"version\": 1,\n    \"name\": \"VideoPlayerInputs\",\n    \"maps\": [\n        {\n            \"name\": \"VideoPlayerControl\",\n            \"id\": \"a22a48bf-a40b-4188-ac90-6f2a3498cd80\",\n            \"actions\": [\n                {\n                    \"name\": \"PlayPause\",\n                    \"type\": \"Button\",\n                    \"id\": \"bf6194d1-d790-40dd-9699-58b0778a4799\",\n                    \"expectedControlType\": \"\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"NextFrame\",\n                    \"type\": \"Button\",\n                    \"id\": \"7afbc1fb-fa4f-4032-a2b9-9485ad21eb28\",\n                    \"expectedControlType\": \"\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"PreviousFrame\",\n                    \"type\": \"Button\",\n                    \"id\": \"9c48ba60-a00c-49a6-acfa-de141ad8c587\",\n                    \"expectedControlType\": \"\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                }\n            ],\n            \"bindings\": [\n                {\n                    \"name\": \"\",\n                    \"id\": \"b2d7b828-0e91-4ef7-9308-db4e970b7cd5\",\n                    \"path\": \"<Keyboard>/space\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"PlayPause\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"a73852a4-224e-43a2-96fa-742190316134\",\n                    \"path\": \"<Keyboard>/rightArrow\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"NextFrame\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"ed2a7e0b-5e6e-436d-973e-f8773242ecfa\",\n                    \"path\": \"<Keyboard>/leftArrow\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"PreviousFrame\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                }\n            ]\n        }\n    ],\n    \"controlSchemes\": []\n}");
		m_VideoPlayerControl = asset.FindActionMap("VideoPlayerControl", throwIfNotFound: true);
		m_VideoPlayerControl_PlayPause = m_VideoPlayerControl.FindAction("PlayPause", throwIfNotFound: true);
		m_VideoPlayerControl_NextFrame = m_VideoPlayerControl.FindAction("NextFrame", throwIfNotFound: true);
		m_VideoPlayerControl_PreviousFrame = m_VideoPlayerControl.FindAction("PreviousFrame", throwIfNotFound: true);
	}

	~VideoPlayerInputs()
	{
	}

	public void Dispose()
	{
		UnityEngine.Object.Destroy(asset);
	}

	public bool Contains(InputAction action)
	{
		return asset.Contains(action);
	}

	public IEnumerator<InputAction> GetEnumerator()
	{
		return asset.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public void Enable()
	{
		asset.Enable();
	}

	public void Disable()
	{
		asset.Disable();
	}

	public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
	{
		return asset.FindAction(actionNameOrId, throwIfNotFound);
	}

	public int FindBinding(InputBinding bindingMask, out InputAction action)
	{
		return asset.FindBinding(bindingMask, out action);
	}
}
