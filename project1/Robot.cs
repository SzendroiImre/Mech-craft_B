/*
 * Created by SharpDevelop.
 * User: Monokli
 * Date: 2018.02.12.
 * Time: 19:46
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace project1
{
	class robot {
	 	part[] pieces = new part[30];
	 	float heat_capacity;
	 	float heat;
	 	List<gun> weapon_group = new List<gun>(); //should be pointers referring to the actual guns..
	 	public robot()
	 	{
	 		heat=0f;
	 		heat_capacity=100;
	 		pieces[0] = new movement("Armored Track\t",98000,98000,700,50);
	 		pieces[1] = new movement("Armored Track\t",98000,98000,700,50);
	 		for(int i=2; i<=6;i++)
	 		{
	 			pieces[i] = new laser("Small Pulse Laser"+(i-1),19000,19000,25,12,5000,0.5F+0.5F*i,3);
	 		}
	 		for(int i=7; i<30;i++)
	 		{
	 			pieces[i] = new part();
	 		}
	 			 		
	 	}
	 	public float getheat() { return heat;}
	 	public void update(float _dt)
	 	{
	 		if(heat>0)
	 		{
	 			heat-=2.5f*_dt;
	 			if(heat<0)
	 			{
	 				heat=0;
	 			}
	 		}
	 		foreach(part p in pieces)
	 		{
	 			p.update(_dt);
	 		}
	 	}
	 	public void diagnose()
	 	{
	 		foreach(part p in pieces)
	 		{
	 			p.print();
	 		}
	 	}
	 	public void alpha()
	 	{
	 		Console.WriteLine("Alpha Strike!");
	 		foreach(part p in pieces)
	 		{
	 			if(p.talk()==parttypes.hw_gun)
	 			{
	 				gun g=(gun)p;
	 				if(heat<heat_capacity)
	 				{
	 					if(g.fire()){
	 						heat+=g.getheat();
	 					}
	 				}
	 				else
	 				{
 						Console.WriteLine("Overheating!");
 					}
	 			}
	 			
	 		}
	 	}
	}
}
