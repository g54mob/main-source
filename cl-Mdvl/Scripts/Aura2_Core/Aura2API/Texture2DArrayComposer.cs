using System;
using System.Collections.Generic;
using UnityEngine;

namespace Aura2API
{
	public class Texture2DArrayComposer
	{
		public bool alwaysGenerateOnUpdate;

		private readonly bool _linear;

		private readonly TextureFormat _requiredTextureFormat;

		private readonly List<Texture> _texturesList;

		public int RequiredSizeX { get; private set; }

		public int RequiredSizeY { get; private set; }

		public int TextureCount => _texturesList.Count;

		public Texture2DArray ArrayTexture { get; private set; }

		public bool HasTexture { get; private set; }

		public bool NeedsToUpdateTexture { get; private set; }

		public event EventHandler OnTextureUpdated;

		public Texture2DArrayComposer(int sizeX, int sizeY, TextureFormat format, bool bypassSrgb)
		{
			_texturesList = new List<Texture>();
			RequiredSizeX = sizeX;
			RequiredSizeY = sizeY;
			_requiredTextureFormat = format;
			_linear = bypassSrgb;
		}

		public void RaiseTextureUpdatedEvent()
		{
			if (this.OnTextureUpdated != null)
			{
				this.OnTextureUpdated(this, new EventArgs());
			}
		}

		public bool AddTexture(Texture texture)
		{
			if (texture != null)
			{
				if (texture.height != RequiredSizeY || texture.width != RequiredSizeX)
				{
					Debug.LogError("Pixel sizes of texture \"" + texture?.ToString() + "\" (" + texture.width + "x" + texture.height + ") does not match the required size of " + RequiredSizeX + "pixels for width and " + RequiredSizeY + "pixels for height.", texture);
					return false;
				}
				if (!_texturesList.Contains(texture))
				{
					_texturesList.Add(texture);
					NeedsToUpdateTexture = true;
					return true;
				}
			}
			return false;
		}

		public bool RemoveTexture(Texture texture)
		{
			if (_texturesList.Contains(texture))
			{
				_texturesList.Remove(texture);
				NeedsToUpdateTexture = true;
				return true;
			}
			return false;
		}

		public bool RemoveTexture(int id)
		{
			if (id < _texturesList.Count)
			{
				_texturesList.RemoveAt(id);
				NeedsToUpdateTexture = true;
				return true;
			}
			return false;
		}

		public void Generate()
		{
			if (!NeedsToUpdateTexture && !alwaysGenerateOnUpdate)
			{
				return;
			}
			if (_texturesList.Count > 0)
			{
				if (NeedsToUpdateTexture)
				{
					if (ArrayTexture != null)
					{
						ArrayTexture.Destroy();
						ArrayTexture = null;
					}
					ArrayTexture = new Texture2DArray(RequiredSizeX, RequiredSizeY, _texturesList.Count, _requiredTextureFormat, mipChain: false, _linear);
				}
				for (int i = 0; i < _texturesList.Count; i++)
				{
					Graphics.CopyTexture(_texturesList[i], 0, 0, 0, 0, RequiredSizeX, RequiredSizeY, ArrayTexture, i, 0, 0, 0);
				}
				HasTexture = true;
			}
			else
			{
				if (ArrayTexture != null)
				{
					ArrayTexture.Destroy();
					ArrayTexture = null;
				}
				HasTexture = false;
			}
			NeedsToUpdateTexture = false;
			RaiseTextureUpdatedEvent();
		}

		public int GetTextureIndex(Texture texture)
		{
			return _texturesList.IndexOf(texture);
		}

		public void ClearTexturesList()
		{
			_texturesList.Clear();
		}

		public void ClearTexturesList(bool needToUpdate)
		{
			NeedsToUpdateTexture = needToUpdate;
			ClearTexturesList();
		}

		public void Resize(int sizeX, int sizeY)
		{
			RequiredSizeX = sizeX;
			RequiredSizeY = sizeY;
			ClearTexturesList();
			NeedsToUpdateTexture = true;
		}

		public void Release()
		{
			if (ArrayTexture != null)
			{
				ArrayTexture.Destroy();
				ArrayTexture = null;
			}
		}
	}
}
