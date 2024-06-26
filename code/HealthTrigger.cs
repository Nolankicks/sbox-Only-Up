using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Sandbox;

[Group( "Trigger" )]
public sealed class HealthTrigger : Component, Component.ITriggerListener //Change "Trigger to the name of your file
{

 bool _iTouching; 

 public void istouching(bool _iTouching)
 {
		if (_iTouching == true)
		{
			
		}
 }



	protected override void OnStart()
    {
      _iTouching = false;
		
    }

    public void OnTriggerEnter( Collider other )
    {
        if ( !other.GameObject.IsValid() )
            return;
			

        var health = other.GameObject.Components.GetInAncestorsOrSelf<HealthManager>();
        if ( health.IsValid() )
        {
            health.OnDeath();
        }
    }

    void ITriggerListener.OnTriggerExit( Collider other ) 
    {

		

	
    

    }

	

	


	
}
