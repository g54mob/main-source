using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CloudGenerator : MonoBehaviour
{
	public GameObject TopLine;

	public GameObject RightLine;

	public GameObject CloudV1Template;

	public GameObject CloudV2Template;

	public GameObject CloudV3Template;

	public GameObject CloudV4Template;

	public GameObject CloudV5Template;

	public GameObject CloudV6Template;

	public List<GameObject> Clouds;

	public List<GameObject> SmallClouds = new List<GameObject>();

	public List<GameObject> Combining = new List<GameObject>();

	private void Start()
	{
	}

	private void FixedUpdate()
	{
		List<GameObject> list = new List<GameObject>();
		List<GameObject> list2 = new List<GameObject>();
		foreach (GameObject cloud in Clouds)
		{
			cloud.transform.position += new Vector3((0.25f + cloud.GetComponent<Cloud>().RandomSpeedDelta) * Time.fixedDeltaTime, 0f, 0f);
			if (cloud.transform.position.x >= RightLine.transform.position.x || !cloud.GetComponent<Cloud>().IsAlive)
			{
				list2.Add(cloud);
			}
		}
		foreach (GameObject smallCloud in SmallClouds)
		{
			smallCloud.transform.position += new Vector3(0f, (0.35f + smallCloud.GetComponent<Cloud>().RandomSpeedDelta) * Time.fixedDeltaTime, 0f);
			if (!smallCloud.GetComponent<Cloud>().IsAlive)
			{
				list2.Add(smallCloud);
			}
			else if (smallCloud.transform.position.y >= TopLine.transform.position.y + smallCloud.GetComponent<Cloud>().RandomHeight)
			{
				list.Add(smallCloud);
			}
		}
		foreach (GameObject item in list)
		{
			SmallClouds.Remove(item);
			Clouds.Add(item);
		}
		foreach (GameObject item2 in list2)
		{
			Clouds.Remove(item2);
			SmallClouds.Remove(item2);
			item2.SetActive(value: false);
			Object.Destroy(item2);
		}
		CombineCloud();
	}

	public void CreateSmallCloud(Vector3 position)
	{
		GameObject gameObject = Object.Instantiate(CloudV1Template, base.transform);
		gameObject.transform.position = position;
		Color color = gameObject.GetComponent<SpriteRenderer>().color;
		color.a = 0f;
		gameObject.GetComponent<SpriteRenderer>().color = color;
		gameObject.transform.localScale = Vector3.zero;
		gameObject.GetComponent<SpriteRenderer>().DOFade(1f, 1f);
		gameObject.transform.DOScale(1f, 4f);
		gameObject.transform.DOLocalMoveY(gameObject.transform.localPosition.y + 2f, 1f);
		SmallClouds.Add(gameObject);
	}

	private void CombineCloud()
	{
		while (true)
		{
			int num = Clouds.Count - 1;
			int num2;
			Cloud.CloudTypeEnum cloudType;
			while (true)
			{
				if (num < 0)
				{
					return;
				}
				for (num2 = Clouds.Count - 1; num2 >= 0; num2--)
				{
					if (num != num2 && Clouds[num].GetComponent<Cloud>().CloudType == Clouds[num2].GetComponent<Cloud>().CloudType)
					{
						cloudType = Clouds[num].GetComponent<Cloud>().CloudType;
						if (Cloud.CanLevelUp(cloudType) && Vector2.Distance(Clouds[num].transform.position, Clouds[num2].transform.position) < 1.5f)
						{
							goto end_IL_02be;
						}
					}
				}
				num--;
				continue;
				end_IL_02be:
				break;
			}
			float x = (Clouds[num].transform.position.x + Clouds[num2].transform.position.x) / 2f;
			float y = (Clouds[num].transform.position.y + Clouds[num2].transform.position.y) / 2f;
			Clouds[num].SetActive(value: false);
			Clouds[num2].SetActive(value: false);
			Object.Destroy(Clouds[num]);
			Object.Destroy(Clouds[num2]);
			Clouds.RemoveAt(num);
			Clouds.RemoveAt(num2);
			GameObject gameObject = null;
			switch (Cloud.NextLevel(cloudType))
			{
			case Cloud.CloudTypeEnum.V1:
				gameObject = Object.Instantiate(CloudV1Template, base.transform);
				break;
			case Cloud.CloudTypeEnum.V2:
				gameObject = Object.Instantiate(CloudV2Template, base.transform);
				break;
			case Cloud.CloudTypeEnum.V3:
				gameObject = Object.Instantiate(CloudV3Template, base.transform);
				break;
			case Cloud.CloudTypeEnum.V4:
				gameObject = Object.Instantiate(CloudV4Template, base.transform);
				break;
			case Cloud.CloudTypeEnum.V5:
				gameObject = Object.Instantiate(CloudV5Template, base.transform);
				break;
			case Cloud.CloudTypeEnum.V6:
				gameObject = Object.Instantiate(CloudV6Template, base.transform);
				break;
			}
			if (gameObject != null)
			{
				gameObject.transform.position = new Vector3(x, y, 0f);
				gameObject.transform.localScale = Vector3.zero;
				gameObject.transform.DOScale(Vector3.one, 0.3f).SetEase(Ease.OutBack);
				Clouds.Add(gameObject);
			}
		}
	}
}
