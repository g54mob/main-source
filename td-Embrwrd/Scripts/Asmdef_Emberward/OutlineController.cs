using System.Collections.Generic;
using HighlightPlus;
using UnityEngine;

public class OutlineController : MonoBehaviour
{
	public enum eOutlineType
	{
		BASIC = 0,
		BUILD_BLUE = 1,
		BUILD_RED = 2,
		BUFF_EFFECT = 3,
		TERRITORY_PLAYER = 4,
		TERRITORY_ENEMY = 5,
		SPECIAL_OBJECT = 6,
		JOYSTICK_CONTROL = 7
	}

	[SerializeField]
	[Header("不同外框樣式的 Profile（順序對應 eOutlineType）")]
	private List<HighlightProfile> list_Profiles;

	private Dictionary<eOutlineType, HighlightEffect> dic_TypeToEffect;

	private Dictionary<Renderer, HashSet<eOutlineType>> dic_RendererToTypes;

	private Dictionary<HighlightEffect, List<Renderer>> _effectToRenderers;

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnRequestAddOutline(Renderer renderer, eOutlineType type)
	{
	}

	private void OnRequestAddOutlineByList(List<Renderer> list_Renderers, eOutlineType type)
	{
	}

	private void OnRequestRemoveOutline(Renderer renderer)
	{
	}

	private void OnRequestRemoveOutlineByList(List<Renderer> list_Renderers)
	{
	}

	private void OnRequestRemoveOutlineByListAndType(List<Renderer> list_Renderers, eOutlineType outlineType)
	{
	}

	private void AddRendererToEffect(HighlightEffect effect, Renderer renderer, eOutlineType type)
	{
	}

	private void RemoveRendererFromEffect(HighlightEffect effect, Renderer renderer)
	{
	}

	private List<Renderer> GetRendererList(HighlightEffect effect)
	{
		return null;
	}
}
