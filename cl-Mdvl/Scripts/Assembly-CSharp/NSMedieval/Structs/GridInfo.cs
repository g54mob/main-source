using NSMedieval.Enums;

namespace NSMedieval.Structs
{
	public struct GridInfo
	{
		private BuildingProperty buildingProperty;

		private BuildingType buildingType;

		private Support wallSupport;

		private int structualIntegrity;

		private bool empty;

		private BuildingType overElement;

		private BuildingProperty overElementProp;

		public BuildingProperty BuildingProperty => buildingProperty;

		public BuildingType BuildingType => buildingType;

		public Support WallSupport => wallSupport;

		public int StructualIntegrity => structualIntegrity;

		public bool Empty
		{
			get
			{
				return empty;
			}
			set
			{
				empty = value;
			}
		}

		public BuildingType OverElement => overElement;

		public BuildingProperty OverElementProp => overElementProp;

		public GridInfo(bool empty = false, BuildingProperty buildProp = BuildingProperty.None, BuildingType buildType = BuildingType.Nothing, Support wallSupp = default(Support), int structIntegr = -1, BuildingType overElement = BuildingType.Nothing, BuildingProperty overElementProp = BuildingProperty.None)
		{
			this.empty = empty;
			buildingProperty = buildProp;
			buildingType = buildType;
			wallSupport = wallSupp;
			structualIntegrity = structIntegr;
			this.overElement = overElement;
			this.overElementProp = overElementProp;
		}

		public void SetBuildingType(BuildingType type)
		{
			buildingType = type;
		}

		public void SetEmpty(bool empty)
		{
			this.empty = empty;
		}

		public void SetOverElement(BuildingType option)
		{
			overElement = option;
		}

		public void SetOverElementProp(BuildingProperty option)
		{
			overElementProp = option;
		}

		public void SetWallSupport(Support support)
		{
			wallSupport = support;
		}

		public void SetStructuralIntegrity(int integrity)
		{
			structualIntegrity = integrity;
		}

		public void SetBuildingProperty(BuildingProperty property)
		{
			buildingProperty = property;
		}

		public void SetBuildingPropertyFlag(bool option, BuildingProperty property)
		{
			if (!option)
			{
				buildingProperty &= (BuildingProperty)(byte)(~(int)property);
			}
			else
			{
				buildingProperty |= property;
			}
		}

		public void SetBuildable(bool option)
		{
			if (!option)
			{
				buildingProperty &= ~BuildingProperty.Buildable;
			}
			else
			{
				buildingProperty |= BuildingProperty.Buildable;
			}
		}

		public void SetTaken(bool option)
		{
			if (!option)
			{
				buildingProperty &= ~BuildingProperty.Taken;
			}
			else
			{
				buildingProperty |= BuildingProperty.Taken;
			}
		}

		public void SetDelete(bool option)
		{
			if (!option)
			{
				buildingProperty &= ~BuildingProperty.Delete;
			}
			else
			{
				buildingProperty |= BuildingProperty.Delete;
			}
		}

		public void SetNextToWall(bool option)
		{
			if (!option)
			{
				buildingProperty &= ~BuildingProperty.NextToWall;
			}
			else
			{
				buildingProperty |= BuildingProperty.NextToWall;
			}
		}

		public void SetBuilt(bool option)
		{
			if (!option)
			{
				buildingProperty &= ~BuildingProperty.Built;
			}
			else
			{
				buildingProperty |= BuildingProperty.Built;
			}
		}

		public void SetDoor(bool option)
		{
			if (!option)
			{
				buildingProperty &= ~BuildingProperty.Door;
			}
			else
			{
				buildingProperty |= BuildingProperty.Door;
			}
		}

		public void SetWindow(bool option)
		{
			if (!option)
			{
				buildingProperty &= ~BuildingProperty.Window;
			}
			else
			{
				buildingProperty |= BuildingProperty.Window;
			}
		}
	}
}
