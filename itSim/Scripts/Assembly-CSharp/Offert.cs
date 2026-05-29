using System;

[Serializable]
public class Offert
{
	private static int idCounter;

	public int id_offert;

	public string name;

	public string desc_main;

	public string desc_01;

	public string desc_02;

	public string desc_03;

	public string name_company;

	public string gross;

	public string description;

	public string proffesion;

	public string location;

	public string[] tag;

	public string exp_day;

	public string level_exp;

	public int logo_company;

	public bool recommend;

	public bool isIT;

	public Offert(string name, string desc_main, string desc_01, string desc_02, string desc_03, string name_company, string gross, string description, string proffesion, string location, string exp_day, string level_exp, string[] tag, int logo_company, bool isIT, bool recommend = false)
	{
	}
}
