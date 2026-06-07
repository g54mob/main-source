using System.Collections.Generic;
using Jundroo.Common.Utils;
using Jundroo.Juicy;
using Jundroo.Juicy.Widgets;
using UnityEngine;

namespace Assets.Scripts.Flight.UI
{
	public class RadioPanelScript : WidgetScript, IRadioPanel
	{
		private Queue<RadioMessageScript> _messages = new Queue<RadioMessageScript>();

		private Dictionary<string, Sprite> _spriteCache = new Dictionary<string, Sprite>();

		public void CreateMessage(string message, string source, string profileImage, string audioFile = null, bool immediate = false)
		{
			RadioMessageScript component = base.Widget.Context.CreateWidgetFromTemplate("radio-message", base.Widget).GetComponent<RadioMessageScript>();
			component.InitializeMessage(message, source, LoadSpriteFromFile(profileImage), (float)message.Length * 0.05f);
			_messages.Enqueue(component);
		}

		public Sprite LoadSpriteFromFile(string path)
		{
			if (!_spriteCache.ContainsKey(path))
			{
				Texture2D texture2D = Utilities.LoadTextureFromFile(path);
				if (texture2D != null)
				{
					texture2D.wrapMode = TextureWrapMode.Clamp;
					_spriteCache[path] = Sprite.Create(texture2D, new Rect(0f, 0f, texture2D.width, texture2D.height), new Vector2(0f, 0f), 100f, 0u, SpriteMeshType.FullRect);
				}
				else
				{
					_spriteCache[path] = null;
					Debug.LogError("Could not load texture from " + path);
				}
			}
			return _spriteCache[path];
		}

		public override void OnWidgetInitialized(Widget widget)
		{
			base.OnWidgetInitialized(widget);
		}

		protected virtual void Update()
		{
			if (_messages.Count <= 0)
			{
				return;
			}
			RadioMessageScript message = _messages.Peek();
			if (message.IsComplete)
			{
				message.Widget.Hide(delegate
				{
					message.Widget.Destroy();
				});
				_messages.Dequeue();
			}
			else if (!message.IsStarted)
			{
				message.Show();
			}
		}
	}
}
