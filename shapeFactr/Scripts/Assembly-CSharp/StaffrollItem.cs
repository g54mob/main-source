using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StaffrollItem : MonoBehaviour
{
	public enum eType
	{
		Blank = 0,
		Image = 1,
		Text = 2
	}

	protected enum eMode
	{
		Move = 0,
		Stop = 1,
		FadeOut = 2,
		FadeIn = 3
	}

	public enum eParentType
	{
		Stafroll = 0,
		Endroll = 1
	}

	[SerializeField]
	public Image m_Icon;

	[SerializeField]
	public TMP_Text m_Text;

	[SerializeField]
	public CanvasGroup m_CanvasGroup;

	protected eMode m_Mode;

	protected StaffrollItemData data;

	protected eType m_Type;

	protected float m_Linefeed;

	protected float m_WaitTime;

	protected bool m_IsAnimationEnd;

	protected Vector3 m_Position;

	protected float m_Height;

	protected float m_startPosY;

	protected float m_Speed;

	protected float m_LineHeight;

	protected float windowWidth;

	protected float windowHeight;

	public bool IsAnimationEnd => false;

	public float WaitTime => 0f;

	public void Setup(StaffrollItemData data, eParentType parentType = eParentType.Stafroll)
	{
	}

	public virtual void Init()
	{
	}

	protected virtual float GetWaitTime()
	{
		return 0f;
	}

	private Color GetTextColor(string _text)
	{
		return default(Color);
	}

	public void SetupBlank(float _linefeed)
	{
	}

	public void SetupImage(string _spriteName, float _width, float _height, float _linefeed)
	{
	}

	public void SetupText(string _text, int _size, Color _color, float _linefeed)
	{
	}

	public void DoAnimation()
	{
	}

	public virtual void Update()
	{
	}

	public void ForceAnimationStop()
	{
	}
}
