using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace DV.TerrainTools
{
	[ExecuteInEditMode]
	public abstract class Point : MonoBehaviour, INotifyPropertyChanged
	{
		public Vector3 position
		{
			get
			{
				return base.transform.position;
			}
			set
			{
				base.transform.position = value;
			}
		}

		public Quaternion rotation
		{
			get
			{
				return base.transform.rotation;
			}
			set
			{
				base.transform.rotation = value;
			}
		}

		public RoadCreator RoadCreator => GetComponentsInParent<RoadCreator>(includeInactive: true).FirstOrDefault();

		public Road Road => GetComponentsInParent<Road>(includeInactive: true).FirstOrDefault();

		public event PropertyChangedEventHandler PropertyChanged;

		protected void SetProperty<T>(ref T field, T value, [CallerMemberName] string name = "")
		{
			if (!EqualityComparer<T>.Default.Equals(field, value))
			{
				field = value;
				this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
			}
		}
	}
}
