using System;
using System.Collections.Generic;
using UnityEngine;

public class JobblyDatabases : MonoBehaviour
{
	[Serializable]
	private class OffertListWrapper
	{
		public List<Offert> offerts;
	}

	public static JobblyDatabases instance;

	[SerializeField]
	public List<Offert> offertlist;

	public string[] d_name_company;

	public string[] d_gross;

	public string[] d_description;

	public string[] d_condition_01;

	public string[] d_condition_02;

	public string[] d_condition_03;

	public string[] d_proffesion;

	public string[] d_location;

	public string[] d_level_exp;

	public string[] d_tag;

	private void Awake()
	{
	}

	public void addOffert(string name, string desc_main, string desc_01, string desc_02, string desc_03, string name_company, string gross, string description, string proffesion, string location, string exp_day, string level_exp, string[] tag, int logo_company, bool isIT = false, bool recommend = false)
	{
	}

	public void ClearData()
	{
	}

	public string JobblyDatabasesToJson()
	{
		return null;
	}

	public void JsonToJobblyDatabases(string json)
	{
	}
}
