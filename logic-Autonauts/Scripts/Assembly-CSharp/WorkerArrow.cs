using UnityEngine;
using UnityEngine.UI;

public class WorkerArrow : Indicator
{
	private Image m_Image;

	private BaseText m_Name;

	private Worker m_Worker;

	public bool m_Visible;

	private bool m_Show;

	private bool m_Pause;

	private bool m_Selected;

	public void Restart()
	{
		UpdateShow();
	}

	protected new void Awake()
	{
		base.Awake();
		m_Visible = false;
		m_Show = false;
		m_Pause = false;
		m_Selected = false;
		m_Offset = 0f;
	}

	public void SetWorker(Worker NewWorker)
	{
		m_Image = base.transform.Find("Image").GetComponent<Image>();
		m_Name = base.transform.Find("Text").GetComponent<BaseText>();
		m_Worker = NewWorker;
		UpdateName();
		if ((bool)TabManager.Instance && TabManager.Instance.m_ActiveTabType == TabManager.TabType.Workers)
		{
			m_Show = true;
			UpdateShow();
		}
		UpdateColour();
	}

	public void UpdateColour()
	{
		Color color = WorkerGroup.m_DefaultColour;
		if (m_Worker.m_Group != null)
		{
			color = m_Worker.m_Group.GetColour();
		}
		float a = 1f;
		if (!m_Pause && !m_Selected)
		{
			a = 0.2f;
		}
		color.a = a;
		m_Image.color = color;
		color = new Color(1f, 1f, 1f, a);
		m_Name.SetColour(color);
	}

	public void UpdateName()
	{
		m_Name.SetText(m_Worker.GetWorkerName());
	}

	public void ShowName(bool Show)
	{
		m_Show = Show;
		UpdateShow();
	}

	public void SetSelected(bool Selected)
	{
		m_Selected = Selected;
		UpdateShow();
	}

	public void SetHighlighted(bool Highlighted)
	{
		string text = "WorkerArrow";
		if (Highlighted)
		{
			text = "WorkerArrowHighlight";
		}
		Sprite sprite = (Sprite)Resources.Load("Textures/Hud/Indicators/" + text, typeof(Sprite));
		m_Image.sprite = sprite;
	}

	private void UpdateShow()
	{
		m_Visible = m_Show || m_Pause;
		base.gameObject.SetActive(m_Visible);
		UpdateColour();
		UpdateIndicator();
	}

	public void Pause(bool Paused)
	{
		m_Pause = Paused;
		UpdateShow();
	}

	public void UpdateIndicator()
	{
		if ((bool)m_Worker)
		{
			UpdateTransform(m_Worker.transform.position + new Vector3(0f, 1f, 0f));
		}
	}
}
