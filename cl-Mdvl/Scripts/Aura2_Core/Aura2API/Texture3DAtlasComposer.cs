using System;
using System.Collections.Generic;
using UnityEngine;

namespace Aura2API
{
	internal class Texture3DAtlasComposer
	{
		private readonly List<Texture3D> _texturesList;

		private readonly TextureFormat _requiredTextureFormat;

		private readonly int _requiredSize;

		public Texture3D VolumeTexture { get; private set; }

		public bool HasVolumeTexture { get; private set; }

		public bool NeedsToUpdateVolumeTexture { get; private set; }

		public event Action OnTextureUpdated;

		public Texture3DAtlasComposer(TextureFormat requiredTextureFormat, int requiredSize)
		{
			_texturesList = new List<Texture3D>();
			_requiredTextureFormat = requiredTextureFormat;
			_requiredSize = requiredSize;
		}

		private void RaiseTextureUpdatedEvent()
		{
			if (this.OnTextureUpdated != null)
			{
				this.OnTextureUpdated();
			}
		}

		public void ClearTextureList()
		{
			_texturesList.Clear();
			NeedsToUpdateVolumeTexture = true;
		}

		public void AddTexture(Texture3D texture)
		{
			if (texture != null)
			{
				if (texture.height != _requiredSize || texture.width != _requiredSize || texture.depth != _requiredSize)
				{
					string[] obj = new string[5]
					{
						"Pixel sizes of Texture3D \"",
						texture?.ToString(),
						"\" does not match the required size of ",
						null,
						null
					};
					int requiredSize = _requiredSize;
					obj[3] = requiredSize.ToString();
					obj[4] = "pixels for every dimensions.";
					Debug.LogError(string.Concat(obj), texture);
				}
				else if (texture.format != _requiredTextureFormat)
				{
					Debug.LogError("Texture format of Texture3D \"" + texture?.ToString() + "\" does not match the required " + _requiredTextureFormat.ToString() + " format.", texture);
				}
				else if (!_texturesList.Contains(texture))
				{
					_texturesList.Add(texture);
					NeedsToUpdateVolumeTexture = true;
				}
			}
		}

		public bool RemoveTexture(Texture3D texture)
		{
			if (_texturesList.Contains(texture))
			{
				_texturesList.Remove(texture);
				NeedsToUpdateVolumeTexture = true;
				return true;
			}
			return false;
		}

		public void Generate()
		{
			if (!NeedsToUpdateVolumeTexture)
			{
				return;
			}
			if (_texturesList.Count > 0)
			{
				Color[] array = new Color[0];
				VolumeTexture = new Texture3D(_requiredSize, _requiredSize, _requiredSize * _texturesList.Count, _requiredTextureFormat, mipChain: false);
				for (int i = 0; i < _texturesList.Count; i++)
				{
					array = array.Append(_texturesList[i].GetPixels());
				}
				VolumeTexture.SetPixels(array);
				VolumeTexture.Apply();
				HasVolumeTexture = true;
			}
			else
			{
				VolumeTexture = null;
				HasVolumeTexture = false;
			}
			NeedsToUpdateVolumeTexture = false;
			RaiseTextureUpdatedEvent();
		}

		public int GetTextureIndex(Texture3D texture)
		{
			return _texturesList.IndexOf(texture);
		}

		public void Release()
		{
			if (VolumeTexture != null)
			{
				VolumeTexture.Destroy();
				VolumeTexture = null;
			}
		}
	}
}
