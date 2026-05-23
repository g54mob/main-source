using System.Collections.Generic;
using Libs;
using UnityEngine;
using UnityEngine.UI;

public class CountdownCtrl : SingletonMonoBehaviour<CountdownCtrl>
{
	[SerializeField]
	private List<Sprite> countSpriteList;

	[SerializeField]
	private Image countImage;

	private float animationSpeed => 0f;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void SetCount(int count)
	{
	}
}
