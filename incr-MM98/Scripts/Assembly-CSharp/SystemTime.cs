using System;
using System.Collections;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class SystemTime : MonoBehaviour
{
	private TMP_Text _text;

	private void Awake()
	{
		_text = GetComponent<TMP_Text>();
	}

	private void Start()
	{
		StartCoroutine(UpdateTime());
	}

	private IEnumerator UpdateTime()
	{
		while (true)
		{
			_text.text = DateTime.Now.ToString("HH:mm");
			yield return new WaitForSeconds(1f);
		}
	}
}
