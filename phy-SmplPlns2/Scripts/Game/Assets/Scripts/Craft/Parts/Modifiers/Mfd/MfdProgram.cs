using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Flight.Combat;
using Assets.Scripts.Lua;
using Assets.Scripts.Lua.Proxies;
using Jundroo.Common.Expressions;
using Jundroo.Common.Utils;
using Jundroo.Juicy;
using Jundroo.Juicy.Widgets;
using Unity.Profiling;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Mfd
{
	public class MfdProgram
	{
		private static class Profile
		{
			public static readonly ProfilerMarker LoadXml = new ProfilerMarker("MfdProgram.LoadXml");

			public static readonly ProfilerMarker OnButtonPressed = new ProfilerMarker("MfdProgram.OnButtonPressed");

			public static readonly ProfilerMarker SelectPage = new ProfilerMarker("MfdProgram.SelectPage");

			public static readonly ProfilerMarker Update = new ProfilerMarker("MfdProgram.Update");
		}

		private WidgetContext _context;

		private AircraftScript _craft;

		private LuaScript _luaScript;

		private List<MfdPage> _pages = new List<MfdPage>();

		private MfdPage _selectedPage;

		private CameraImageScript _targetingPodCamera;

		[Exposed(Name = "mfd")]
		public MfdProxy MfdProxy { get; private set; }

		public Widget RootWidget => _context.Root;

		public MfdPage SelectedPage
		{
			get
			{
				return _selectedPage;
			}
			set
			{
				if (_selectedPage != null)
				{
					_selectedPage.Widget.Visible = false;
				}
				_selectedPage = value;
				if (_selectedPage != null)
				{
					_selectedPage.Widget.Visible = true;
					if (_targetingPodCamera == null)
					{
						RawImageWidget rawImageWidget = _context.Root.FindWidget<RawImageWidget>("tgp-camera");
						if (rawImageWidget != null)
						{
							_targetingPodCamera = rawImageWidget.gameObject.AddComponent<CameraImageScript>();
							_targetingPodCamera.Source = TargetingPod;
						}
					}
				}
				_luaScript.Call("onPageSelected", _selectedPage?.Id);
			}
		}

		public TargetingPodScript TargetingPod { get; private set; }

		[Exposed(Name = "craft")]
		private CraftProxy CraftProxy { get; set; }

		public MfdProgram(AircraftScript craft, int targetingPodPartId)
		{
			_craft = craft;
			TargetingPod = craft.Aircraft.Assembly.GetPartById(targetingPodPartId)?.PartScript?.GetModifier<TargetingPodScript>();
			if (TargetingPod == null)
			{
				TargetingPod = craft.GetComponentInChildren<TargetingPodScript>();
			}
		}

		public void LoadXml(XElement xml, RectTransform parent)
		{
			using (Profile.LoadXml.Auto())
			{
				_context = Game.Instance.UserInterface.CreateContext(parent, this);
				XElement xElement = xml.Element("Script");
				string text = xElement.Attribute("file")?.Value;
				string text2 = null;
				text2 = ((text == null) ? xElement.Value : Game.Instance.ResourceLoader.LoadText(text));
				_luaScript = new LuaScript();
				Context expressionContext = new Context(true, this);
				ProxyFactory proxyFactory = new ProxyFactory(_luaScript, expressionContext);
				proxyFactory.Register((Widget x) => new WidgetProxy(x, proxyFactory));
				proxyFactory.Register((AircraftScript x) => new CraftProxy(x, proxyFactory));
				proxyFactory.Register((AircraftControls x) => new CraftControlsProxy(x, proxyFactory));
				proxyFactory.Register((TargetingSystem x) => new TargetingSystemProxy(x, proxyFactory));
				proxyFactory.Register((TrackedTarget x) => new TargetProxy(x, proxyFactory));
				proxyFactory.Register((WeaponSystem x) => new WeaponSystemProxy(x, proxyFactory));
				proxyFactory.Register((MfdProgram x) => new MfdProxy(x, proxyFactory));
				_luaScript.RegisterType<TargetingSystemMode>(includeStatic: true);
				_luaScript.RegisterType<UnitType>(includeStatic: true);
				_luaScript.RegisterType<Utils>(includeStatic: true);
				CraftProxy = proxyFactory.GetOrCreateProxy<CraftProxy>(_craft);
				MfdProxy = proxyFactory.GetOrCreateProxy<MfdProxy>(this);
				_luaScript.RegisterObject("craft", CraftProxy);
				_luaScript.RegisterObject("mfd", MfdProxy);
				_luaScript.RunScript(text2);
				XElement xElement2 = xml.Element("UI");
				string text3 = xElement2.Attribute("file")?.Value;
				xElement2 = ((text3 == null) ? (xElement2.FirstNode as XElement) : Game.Instance.ResourceLoader.LoadXml(text3).Root);
				_context.ExpressionSource = new DynamicExpressionSource(expressionContext);
				_context.LoadWidgetFromXml(xElement2, null);
				_luaScript.Call("initialize");
				XElement xElement3 = xml.Element("Pages");
				foreach (XElement item in xElement3.Elements())
				{
					MfdPage mfdPage = new MfdPage(item);
					mfdPage.Widget = _context.Root.FindWidget(mfdPage.Id);
					_pages.Add(mfdPage);
				}
				string startPageId = xElement3.Attribute("startPage")?.Value;
				MfdPage selectedPage = _pages.FirstOrDefault((MfdPage x) => x.Id == startPageId) ?? _pages.First();
				SelectedPage = selectedPage;
			}
		}

		public void OnButtonPressed(int buttonID, bool pressed)
		{
			using (Profile.OnButtonPressed.Auto())
			{
				if (pressed)
				{
					_luaScript.Call("onMfdButtonPressed", buttonID);
				}
				else
				{
					_luaScript.Call("onMfdButtonReleased", buttonID);
				}
			}
		}

		public void SelectPage(string id)
		{
			using (Profile.SelectPage.Auto())
			{
				MfdPage mfdPage = _pages.FirstOrDefault((MfdPage x) => x.Id == id);
				if (mfdPage != null)
				{
					SelectedPage = mfdPage;
				}
				else
				{
					Debug.LogWarning("Could not find page with id '" + id + "'");
				}
			}
		}

		public void Update()
		{
			using (Profile.Update.Auto())
			{
				_luaScript.Call("update");
				_context.LateUpdate();
			}
		}
	}
}
