using App.Data;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TreeChain : ActiveComponent
{
	public bool hoverChain;

	[SceneBind("Hover")]
	public Image hover;

	public LevelTreeController questIn;

	public LevelTreeController questOut;

	private Vector3 defaultScale;

	private bool fake;

	private bool completed;

	private Vector3 shift;

	private float spdCoef = 1f;

	private Color col;

	private bool inited;

	public void OnPointerClick(PointerEventData pointerEventData)
	{
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		RedrawChooseChain();
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		RedrawChooseChain();
	}

	private bool CheckLineEndCompleted(QuestLine.Quest q)
	{
		if (q == null)
		{
			return false;
		}
		BaseQuest baseQuestByKeyHash = Logic.GetBaseQuestByKeyHash(q.GetName().GetHashCode());
		if (!q.IsCompleted())
		{
			if (baseQuestByKeyHash.Main == 1)
			{
				return baseQuestByKeyHash.Locked == 1;
			}
			return false;
		}
		return true;
	}

	public void SetEnds(GameObject inG, GameObject outG, bool fake = false)
	{
		SceneBindContainer.BindObjects(this, base.transform);
		questIn = inG.GetComponentInChildren<LevelTreeController>();
		questOut = outG.GetComponentInChildren<LevelTreeController>();
		this.fake = fake;
		if (questIn.gameObject != null && questOut.gameObject != null && !fake)
		{
			completed = true;
			QuestLine.Quest quest = QuestLine.GetQuest(questOut.gameObject.name);
			BaseQuest baseQuestByKeyName = Logic.GetBaseQuestByKeyName(questOut.gameObject.name);
			completed = CheckLineEndCompleted(quest) || (baseQuestByKeyName.Main == 1 && baseQuestByKeyName.Locked == 1);
			if (!completed && hover != null)
			{
				completed = false;
				col = Logic.GetColor("DARKGREY");
				hover.color = col;
			}
		}
	}

	protected override void OnInit()
	{
		SceneBindContainer.BindObjects(this, base.transform);
		col = Logic.GetColor("GREEN");
		hover.color = col;
		hoverChain = false;
		RedrawChooseChain();
		defaultScale = base.gameObject.transform.GetComponent<RectTransform>().localScale;
		shift = new Vector3(0f, 0f, 0f);
	}

	public void RedrawChooseChain()
	{
		if (hover == null)
		{
			OnInit();
		}
		hover.gameObject.SetActive(hoverChain);
	}

	public void SetHover(bool hoverTF)
	{
		hoverChain = hoverTF;
		if (hoverTF)
		{
			col = Logic.GetColor("WARNING");
		}
		else if (completed)
		{
			col = Logic.GetColor("GREEN");
		}
		else
		{
			col = Logic.GetColor("DARKGREY");
		}
		hover.color = col;
	}

	private void Draw(Vector3 left, Vector3 right)
	{
		base.transform.position = new Vector3((right.x + left.x) / 2f, (right.y + left.y) / 2f, 1f);
		base.transform.rotation = new Quaternion(0f, 0f, 0f, 1f);
		base.transform.Rotate(new Vector3(0f, 0f, -57.29578f * Mathf.Atan2(right.x - left.x, right.y - left.y)));
		left.z = 0f;
		right.z = 0f;
		float magnitude = (left - right).magnitude;
		magnitude /= 100f;
		if (questIn != null && questOut != null && questIn.constr != null && questOut.constr != null && questIn.constr.Main == 1)
		{
			_ = questOut.constr.Main;
			_ = 1;
		}
		base.transform.localScale = new Vector3(1f, defaultScale.y * magnitude, 1f);
		magnitude *= 100f;
		GlowLineScale(magnitude, (right.x - left.x) / magnitude, (right.y - left.y) / magnitude, left);
	}

	private void GlowLineScale(float len, float sin, float cos, Vector3 right)
	{
		hover.gameObject.SetActive(value: true);
		hover.enabled = true;
	}

	private void FixedUpdate()
	{
		if (!inited && questIn.gameObject != null && questOut.gameObject != null)
		{
			if (questIn.hidden && questOut.hidden && !fake)
			{
				base.gameObject.SetActive(value: false);
				base.enabled = false;
			}
			else
			{
				inited = true;
				Draw(questIn.transform.position, questOut.transform.position);
			}
		}
	}
}
