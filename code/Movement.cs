public class Movement : Component
{
    [Property]
    public Transform Transform1 { get; set; }

    [Property]
    public Transform Transform2 { get; set; }

    [Property]
    public bool ShouldMove { get; set; } = false;
	[Property] public SoundEvent soundEvent {get; set;}
    

    private bool _swapTransforms = false;
    private Transform _desiredTransform;

    protected override void OnUpdate()
    {
        base.OnUpdate();

        if ( ShouldMove )
        {
            // select desired transform
            _desiredTransform = _swapTransforms ? Transform1 : Transform2;

            // if we are close in position to the desired transform, swap em
            if ( GameObject.Transform.World.Position.DistanceSquared( _desiredTransform.Position ) < 100.0f )
            {
                // swap em now
                _swapTransforms = !_swapTransforms;
				Sound.Play(soundEvent);
                
            }

            GameObject.Transform.Position = GameObject.Transform.Position.LerpTo( _desiredTransform.Position, Time.Delta * 1f );
        }
    }
}
