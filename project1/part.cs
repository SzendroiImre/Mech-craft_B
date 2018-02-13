/*
 * Created by SharpDevelop.
 * User: Monokli
 * Date: 2018.02.13.
 * Time: 21:25
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace project1
{
	class part
	{
		protected string name;
		private int weight;
		private int health;
		private int points;
		private int mhealth;
		
		public part()
		{
			name="Full Cube Block";
			weight=20;
			points=1;
			health=2500;
			mhealth=2500;
		}
		public part(string _name, int _health, int _mhealth, int _weight, int _points)
		{
			name=_name;
			health=_health;
			mhealth=_mhealth;
			weight=_weight;
			points=_points;
		}
		public string getname()
		{
			return name;
		}
		public int getweight()
		{
			return weight;
		}
		public int gethealth()
		{
			return health;
		}
		public int getpoints()
		{
			return points;
		}
		public bool takedamage(int damage)
		{
			if(damage>=0)
			{
				if(health-damage<=0)
				{
					health=0;
					return true;
				}
				else health-=damage;
			}
			return false;
		}
		public void print()
		{
			Console.WriteLine("{3} \t{0} \t\t{1} hp \t{2}kg \t {4} cpu",name, health, weight, talk(), points);
		}
		public virtual parttypes talk()
		{
			return parttypes.chassis;
		}
		public virtual void update(float _dt)
		{
			
		}
	}
	 class gun : part {
	    int damage;
	    float refire;
	    int heat; //all >0
	    float status;
	 	public gun(string _name, int _health, int _mhealth, int _weight, int _points, int _damage, float _refire, int _heat) : base( _name, _health, _mhealth, _weight, _points)
	 	{
	 		damage=_damage;
	 		refire=_refire;
	 		heat=_heat;
	 		//stuff that needs doing
	 		status = 0;
	 	}
	 	 public bool fire()
	 	{
	 	 	if(isready())
	 	 	{
	 	 		status=refire;
	 	 		Console.WriteLine("{0} firing, {1} damage",name,damage);
	 			return true;
	 	 	}
	 	 	Console.WriteLine("{0} is recharging {1} seconds remaining",name,status);
	 	 	return false;
	 	}
	 	 public int getheat()
	 	 {
	 	 	return heat;
	 	 }
	 	 public int getdamage()
	 	 {
	 	 	return damage;
	 	 }
	 	 public bool isready()
	 	 {
	 	 	return status==0;
	 	 }
	 	 public override parttypes talk()
	 	 {
	 	 	return parttypes.hw_gun;
	 	 }
	 	 public override void update(float _dt)
	 	 {
	 	 	if(status>0)
	 	 	{
		 	 	status-=_dt;
		 	 	if(status<0)
		 	 	{
		 	 		status=0;
		 	 	}	
	 	 	}
	 	 }
	 }
	 class movement : part {
	 	public movement(string _name, int _health, int _mhealth, int _weight, int _points) : base( _name, _health, _mhealth, _weight, _points)
	 	{
	 		//stuff that needs doing
	 	}
	 	 public override parttypes talk()
	 	{
	 		return parttypes.hw_mobility;
	 	}
	 }
	 
	 class ballistic : gun {
	 	public ballistic(string _name, int _health, int _mhealth, int _weight, int _points, int _damage, float _refire, int _heat) : base( _name, _health, _mhealth, _weight, _points, _damage, _refire, _heat)
	 	{
	 		//stuff that needs doing
	 	}
	 	
	 }
	 class laser : gun {
	 	public laser(string _name, int _health, int _mhealth, int _weight, int _points, int _damage, float _refire, int _heat) : base( _name, _health, _mhealth, _weight, _points, _damage, _refire, _heat)
	 	{
	 		//stuff that needs doing
	 	}
	 	
	 }
}
