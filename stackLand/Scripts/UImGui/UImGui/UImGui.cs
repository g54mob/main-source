using System;
using ImGuiNET;
using UImGui.Assets;
using UImGui.Events;
using UImGui.Platform;
using UImGui.Renderer;
using UnityEngine;
using UnityEngine.Rendering;

namespace UImGui
{
	public class UImGui : MonoBehaviour
	{
		private Context _context;

		private IRenderer _renderer;

		private IPlatform _platform;

		private CommandBuffer _renderCommandBuffer;

		[SerializeField]
		private Camera _camera;

		[SerializeField]
		private RenderImGui _renderFeature;

		[SerializeField]
		private RenderType _rendererType;

		[SerializeField]
		private InputType _platformType;

		[Tooltip("Null value uses default imgui.ini file.")]
		[SerializeField]
		private IniSettingsAsset _iniSettings;

		[Header("Configuration")]
		[SerializeField]
		private UIOConfig _initialConfiguration = new UIOConfig
		{
			ImGuiConfig = (ImGuiConfigFlags.NavEnableKeyboard | ImGuiConfigFlags.DockingEnable),
			DoubleClickTime = 0.3f,
			DoubleClickMaxDist = 6f,
			DragThreshold = 6f,
			KeyRepeatDelay = 0.25f,
			KeyRepeatRate = 0.05f,
			FontGlobalScale = 1f,
			FontAllowUserScaling = false,
			DisplayFramebufferScale = Vector2.one,
			MouseDrawCursor = false,
			TextCursorBlink = false,
			ResizeFromEdges = true,
			MoveFromTitleOnly = true,
			ConfigMemoryCompactTimer = 1f
		};

		[SerializeField]
		private FontInitializerEvent _fontCustomInitializer = new FontInitializerEvent();

		[SerializeField]
		private FontAtlasConfigAsset _fontAtlasConfiguration;

		[Header("Customization")]
		[SerializeField]
		private ShaderResourcesAsset _shaders;

		[SerializeField]
		private StyleAsset _style;

		[SerializeField]
		private CursorShapesAsset _cursorShapes;

		[SerializeField]
		private bool _doGlobalEvents = true;

		public CommandBuffer CommandBuffer => _renderCommandBuffer;

		public event Action<UImGui> Layout;

		public event Action<UImGui> OnInitialize;

		public event Action<UImGui> OnDeinitialize;

		public void Reload()
		{
			OnDisable();
			OnEnable();
		}

		public void SetUserData(IntPtr userDataPtr)
		{
			_initialConfiguration.UserData = userDataPtr;
			ImGuiIOPtr iO = ImGui.GetIO();
			_initialConfiguration.ApplyTo(iO);
		}

		public void SetCamera(Camera camera)
		{
			if (camera == null)
			{
				base.enabled = false;
				throw new Exception($"Fail: {camera} is null.");
			}
			OnDisable();
			_camera = camera;
			OnEnable();
		}

		private void Awake()
		{
			_context = UImGuiUtility.CreateContext();
		}

		private void OnDestroy()
		{
			UImGuiUtility.DestroyContext(_context);
		}

		private void OnEnable()
		{
			_camera = Camera.main;
			if (_camera == null)
			{
				Fail("_camera");
			}
			if (_renderFeature == null && RenderUtility.IsUsingURP())
			{
				Fail("_renderFeature");
			}
			_renderCommandBuffer = RenderUtility.GetCommandBuffer(Constants.UImGuiCommandBuffer);
			if (RenderUtility.IsUsingURP())
			{
				_renderFeature.CommandBuffer = _renderCommandBuffer;
			}
			else if (!RenderUtility.IsUsingHDRP())
			{
				_camera.AddCommandBuffer(CameraEvent.AfterEverything, _renderCommandBuffer);
			}
			UImGuiUtility.SetCurrentContext(_context);
			ImGuiIOPtr iO = ImGui.GetIO();
			_initialConfiguration.ApplyTo(iO);
			_style?.ApplyTo(ImGui.GetStyle());
			_context.TextureManager.BuildFontAtlas(iO, in _fontAtlasConfiguration, _fontCustomInitializer);
			_context.TextureManager.Initialize(iO);
			IPlatform platform = PlatformUtility.Create(_platformType, _cursorShapes, _iniSettings);
			SetPlatform(platform, iO);
			if (_platform == null)
			{
				Fail("_platform");
			}
			SetRenderer(RenderUtility.Create(_rendererType, _shaders, _context.TextureManager), iO);
			if (_renderer == null)
			{
				Fail("_renderer");
			}
			if (_doGlobalEvents)
			{
				UImGuiUtility.DoOnInitialize(this);
			}
			this.OnInitialize?.Invoke(this);
			void Fail(string reason)
			{
				base.enabled = false;
				throw new Exception("Failed to start: " + reason + ".");
			}
		}

		private void OnDisable()
		{
			UImGuiUtility.SetCurrentContext(_context);
			ImGuiIOPtr iO = ImGui.GetIO();
			SetRenderer(null, iO);
			SetPlatform(null, iO);
			UImGuiUtility.SetCurrentContext(null);
			_context.TextureManager.Shutdown();
			_context.TextureManager.DestroyFontAtlas(iO);
			if (RenderUtility.IsUsingURP())
			{
				if (_renderFeature != null)
				{
					_renderFeature.CommandBuffer = null;
				}
			}
			else if (_camera != null)
			{
				_camera.RemoveCommandBuffer(CameraEvent.AfterEverything, _renderCommandBuffer);
			}
			if (_renderCommandBuffer != null)
			{
				RenderUtility.ReleaseCommandBuffer(_renderCommandBuffer);
			}
			_renderCommandBuffer = null;
			if (_doGlobalEvents)
			{
				UImGuiUtility.DoOnDeinitialize(this);
			}
			this.OnDeinitialize?.Invoke(this);
		}

		private void Update()
		{
			UImGuiUtility.SetCurrentContext(_context);
			ImGuiIOPtr iO = ImGui.GetIO();
			_context.TextureManager.PrepareFrame(iO);
			_platform.PrepareFrame(iO, _camera.pixelRect);
			ImGui.NewFrame();
			try
			{
				if (_doGlobalEvents)
				{
					UImGuiUtility.DoLayout(this);
				}
				this.Layout?.Invoke(this);
			}
			finally
			{
				ImGui.Render();
			}
			_renderCommandBuffer.Clear();
			_renderer.RenderDrawLists(_renderCommandBuffer, ImGui.GetDrawData());
		}

		private void SetRenderer(IRenderer renderer, ImGuiIOPtr io)
		{
			_renderer?.Shutdown(io);
			_renderer = renderer;
			_renderer?.Initialize(io);
		}

		private void SetPlatform(IPlatform platform, ImGuiIOPtr io)
		{
			_platform?.Shutdown(io);
			_platform = platform;
			_platform?.Initialize(io, _initialConfiguration, "Unity " + _platformType);
		}
	}
}
