using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlantsPopUp : MonoBehaviour
{
	private List<Transform> plantsList = new List<Transform>();

	private int index;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.O))
		{
			HidePlants();
		}
		if (Input.GetKeyDown(KeyCode.P) && plantsList != null)
		{
			StartCoroutine(SpawnPlants());
		}
		if (Input.GetKeyDown(KeyCode.L))
		{
			ShowPlants();
		}
	}

	private IEnumerator SpawnPlants()
	{
		index = 0;
		while (index < plantsList.Count)
		{
			Animate(plantsList[index]);
			index++;
			yield return new WaitForSeconds(0.1f);
		}
	}

	private void Animate(Transform plantTransform)
	{
		SoundManager.Instance.OnPlantPlaced();
		plantTransform.gameObject.SetActive(value: true);
		float posY = plantTransform.position.y;
		plantTransform.DOMoveY(posY + 1f, 0.15f).SetEase(Ease.InSine).OnComplete(delegate
		{
			plantTransform.DOMoveY(posY, 0.1f).SetEase(Ease.OutSine);
		});
		plantTransform.DOScaleY(1.1f, 0.1f).SetEase(Ease.InOutSine).OnComplete(delegate
		{
			plantTransform.DOScaleY(0.9f, 0.05f).SetEase(Ease.InOutSine).OnComplete(delegate
			{
				plantTransform.DOScaleY(1.1f, 0.05f).SetEase(Ease.InOutSine).OnComplete(delegate
				{
					plantTransform.DOScaleY(0.9f, 0.05f).SetEase(Ease.InOutSine).OnComplete(delegate
					{
						plantTransform.DOScaleY(1f, 0.1f).SetEase(Ease.InOutSine);
					});
				});
			});
		});
	}

	private void HidePlants()
	{
		if (base.transform.childCount > 0)
		{
			index = 0;
			plantsList.Clear();
			for (int i = 0; i < base.transform.childCount; i++)
			{
				plantsList.Add(base.transform.GetChild(i));
				plantsList[i].gameObject.SetActive(value: false);
			}
		}
	}

	private void ShowPlants()
	{
		if (base.transform.childCount > 0)
		{
			index = 0;
			for (int i = 0; i < base.transform.childCount; i++)
			{
				plantsList[i].gameObject.SetActive(value: true);
			}
		}
		plantsList.Clear();
	}
}
