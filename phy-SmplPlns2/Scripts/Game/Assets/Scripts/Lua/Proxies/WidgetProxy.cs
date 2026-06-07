using System;
using Jundroo.Juicy.Widgets;
using MoonSharp.Interpreter;
using UnityEngine;

namespace Assets.Scripts.Lua.Proxies
{
	[MoonSharpUserData]
	public class WidgetProxy
	{
		private ProxyFactory _factory;

		private Widget _widget;

		public string Data
		{
			get
			{
				return _widget.Data;
			}
			set
			{
				_widget.Data = value;
			}
		}

		public bool Flagged
		{
			get
			{
				return _widget.Flagged;
			}
			set
			{
				_widget.Flagged = value;
			}
		}

		public string Id => _widget.Id;

		public bool IsDestroyed => _widget == null;

		public WidgetProxy Parent => _factory.GetOrCreateProxy<WidgetProxy>(_widget.Parent);

		public bool Visible
		{
			get
			{
				return _widget.Visible;
			}
			set
			{
				_widget.Visible = value;
			}
		}

		public event EventHandler Clicked;

		public event EventHandler Destroyed;

		[MoonSharpHidden]
		public WidgetProxy(Widget widget, ProxyFactory factory)
		{
			_widget = widget;
			_widget.Destroyed += OnWidgetDestroyed;
			_widget.Clicked += OnWidgetClicked;
			_factory = factory;
		}

		public bool AddClass(string className)
		{
			return _widget.AddClass(className);
		}

		public void AddWidget(WidgetProxy widget)
		{
			_widget.AddWidget(widget._widget);
		}

		public void Destroy()
		{
			_widget.Destroy();
		}

		public WidgetProxy FindParentWidget(string id)
		{
			return _factory.GetOrCreateProxy<WidgetProxy>(_widget.FindParentWidget(id));
		}

		public WidgetProxy FindWidget(string id)
		{
			return _factory.GetOrCreateProxy<WidgetProxy>(_widget.FindWidget(id));
		}

		public WidgetProxy GetChild(int index)
		{
			return _factory.GetOrCreateProxy<WidgetProxy>(_widget.Widgets[index]);
		}

		public int GetChildCount()
		{
			return _widget.Widgets.Count;
		}

		public bool HasClass(string className)
		{
			return _widget.HasClass(className);
		}

		public bool RemoveClass(string className)
		{
			return _widget.RemoveClass(className);
		}

		public void SetIndex(int index)
		{
			_widget.SetIndex(index);
		}

		public void SetStyle(string name, string value)
		{
			if (value != _widget.GetStyle(name))
			{
				_widget.SetStyle(name, value);
			}
		}

		private void OnWidgetClicked(Widget widget)
		{
			try
			{
				this.Clicked?.Invoke(this, EventArgs.Empty);
			}
			catch (Exception ex)
			{
				Debug.LogError("Exception in Clicked event handler: " + ex.Message);
			}
		}

		private void OnWidgetDestroyed(Widget widget)
		{
			widget.Clicked -= OnWidgetClicked;
			widget.Destroyed -= OnWidgetDestroyed;
			try
			{
				this.Destroyed?.Invoke(this, EventArgs.Empty);
			}
			catch (Exception ex)
			{
				Debug.LogError("Exception in Destroyed event handler: " + ex.Message);
			}
			_widget = null;
		}
	}
}
