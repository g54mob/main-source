using System;
using UnityEngine;
using UnityEngine.PajamaLlama;

[CreateAssetMenu(menuName = "Flotsam/Settings/Cursor Settings")]
public class CursorSettings : ScriptableObject
{
	[Serializable]
	internal struct CursorTexture
	{
		[SerializeField]
		[Tooltip("The cursor state.")]
		internal CursorState State;

		[SerializeField]
		[Tooltip("The cursor texture.")]
		internal Texture2D Texture;
	}

	[Header("Defaults")]
	public float TooltipDelay;

	[Tooltip("Layer mask used to check which object is under the cursor")]
	public LayerMask SelectionMask;

	[Tooltip("Layer mask used to get the building position that is under the cursor")]
	public LayerMask BuildingPositionMask;

	[Header("Overrides")]
	[Tooltip("Array that contains the CursorProperties for persistence.")]
	[SerializeField]
	private CursorProperties[] _cursorProperties;

	[Header("Cursors")]
	[Tooltip("The offset from the top left of the texture to use as the target point.")]
	public Vector2 CursorHotSpot = Vector2.zero;

	[Space]
	[SerializeField]
	[Tooltip("List of cursor states and the textures they use")]
	[NamedArrayElement(new string[] { "State" })]
	private CursorTexture[] _cursorTextures;

	[Obsolete("Using Cursor Settings to persist references to cursor properties has been depricated. Use PersistenceManager.TryReturnPropertiesReference instead.")]
	public bool TryReturnCursorProperties(int index, out CursorProperties cursorProperties)
	{
		if (-1 < index && index < _cursorProperties.Length)
		{
			cursorProperties = _cursorProperties[index];
			return true;
		}
		cursorProperties = null;
		return false;
	}

	[Obsolete("Using Cursaor Settings to persist references to cursor properties has been depricated. Use PersistenceManager.ReturnPropertiesIndex instead.")]
	public int ReturnPropertiesIndex(CursorProperties cursorProperties)
	{
		int num = _cursorProperties.Length;
		for (int i = 0; i < num; i++)
		{
			CursorProperties cursorProperties2 = _cursorProperties[i];
			if (cursorProperties == cursorProperties2)
			{
				return i;
			}
		}
		throw new NotSupportedException($"Cursor properties are missing! The cursor property ({cursorProperties.name} cannot be persisted!");
	}

	public Texture2D ReturnCursorTexture(CursorState cursorState)
	{
		int num = _cursorTextures.Length;
		for (int i = 0; i < num; i++)
		{
			CursorTexture cursorTexture = _cursorTextures[i];
			if (cursorTexture.State == cursorState)
			{
				return cursorTexture.Texture;
			}
		}
		return null;
	}
}
