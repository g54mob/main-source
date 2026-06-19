using Loxodon.Framework.ViewModels;
using UnityEngine;

namespace Loxodon.Framework.Tutorials
{
	public class VariableViewModel : ViewModelBase
	{
		private bool remember;

		private string username;

		private string email;

		private Color color;

		private Vector3 vector;

		public string Username
		{
			get
			{
				return username;
			}
			set
			{
				Set(ref username, value, "Username");
			}
		}

		public string Email
		{
			get
			{
				return email;
			}
			set
			{
				Set(ref email, value, "Email");
			}
		}

		public bool Remember
		{
			get
			{
				return remember;
			}
			set
			{
				Set(ref remember, value, "Remember");
			}
		}

		public Vector3 Vector
		{
			get
			{
				return vector;
			}
			set
			{
				Set(ref vector, value, "Vector");
			}
		}

		public Color Color
		{
			get
			{
				return color;
			}
			set
			{
				Set(ref color, value, "Color");
			}
		}

		public void OnSubmit()
		{
			Debug.LogFormat("username:{0} email:{1} remember:{2} vector:{3} color:{4}", username, email, remember, vector, color);
		}
	}
}
