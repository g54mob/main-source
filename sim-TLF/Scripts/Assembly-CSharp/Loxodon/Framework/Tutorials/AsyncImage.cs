using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Loxodon.Framework.Tutorials
{
	public class AsyncImage : Image
	{
		private string spriteName;

		private Material originMaterial;

		private CancellationTokenSource source;

		public Sprite loadingSprite;

		public Material loadingMaterial;

		public string SpriteName
		{
			get
			{
				return spriteName;
			}
			set
			{
				if (!string.Equals(spriteName, value))
				{
					spriteName = value;
					OnSpriteNameChanged(spriteName);
				}
			}
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			originMaterial = material;
		}

		protected async void OnSpriteNameChanged(string spriteName)
		{
			if (string.IsNullOrEmpty(spriteName))
			{
				material = originMaterial;
				base.sprite = null;
				return;
			}
			if (source != null)
			{
				source.Cancel();
			}
			source = new CancellationTokenSource();
			CancellationToken token = source.Token;
			try
			{
				base.sprite = loadingSprite;
				material = loadingMaterial;
				Sprite sprite = await LoadSprite(spriteName);
				if (!token.IsCancellationRequested)
				{
					material = originMaterial;
					base.sprite = sprite;
					source = null;
				}
			}
			catch
			{
				if (!token.IsCancellationRequested)
				{
					material = originMaterial;
					base.sprite = null;
					source = null;
				}
			}
		}

		protected async Task<Sprite> LoadSprite(string spriteName)
		{
			return (Sprite)(await Resources.LoadAsync<Sprite>(spriteName));
		}
	}
}
