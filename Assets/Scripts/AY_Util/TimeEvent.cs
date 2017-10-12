using UnityEngine;
using UnityEngine.Assertions;

namespace AY_Util
{
    /// <summary>
    /// Use this class when you need timer event.
    /// And you should set action implemented instance to mActions.
    /// </summary>
    public class TimeEvent : MonoBehaviour
    {
        /// <summary>
        /// Event array size.
        /// </summary>
        [SerializeField]
        private const int SIZE = 1;

        /// <summary>
        /// When this event fired, then call these events.
        /// </summary>
        [SerializeField]
        private TimeEvent[] mActions = new TimeEvent[SIZE];

        /// <summary>
        /// Event execution time.
        /// If you want not to do action, then this set under 0.
        /// </summary>
        [SerializeField]
        private float mEventFireTime = -1;

        /// <summary>
        /// When event fired, then update this time.
        /// </summary>
        [SerializeField]
        private float mRepeaterTime = -1;

        /// <summary>
        /// You can change count stat time.
        /// </summary>
        private float mStart = 0;

        /// <summary>
        /// This is Action event processes.
        /// </summary>
        /// <param name="passed"></param>
        protected virtual void TimeAction ( float passed )
        {
            string msg = "Call time action ({0})" + passed;
            Log.DebugThrow( msg );
        }

        /// <summary>
        /// Set to fire time.
        /// </summary>
        /// <param name="fire">new fire time.</param>
        protected void SetFireTime(float fire )
        {
            mEventFireTime = fire;
        }

        /// <summary>
        /// Set repeat time.
        /// If you want to end of repeat, then you should set under 0.
        /// </summary>
        /// <param name="repeater">repeat time.</param>
        protected void SetRepeaterTime(float repeater)
        {
            mRepeaterTime = repeater;
        }

        /// <summary>
        /// When debug build, then set debug function.
        /// </summary>
        private void AddDebugFire ( )
        {
            if (!Debug.isDebugBuild) return;
            TimeEvent[] temp = new TimeEvent[SIZE + 1];
            temp[0] = this;
            for (int i = 0; i < SIZE; i++) temp[i + 1] = mActions[i];
            mActions = temp;

        }

        /// <summary>
        /// Setup start data.
        /// Add debug fire and start time set.
        /// </summary>
        private void Start ( )
        {
            AddDebugFire();
            mStart = Time.time;
        }

        /// <summary>
        /// If time passed fire time, then call all of time action.
        /// </summary>
        private void Update ( )
        {
            if( mEventFireTime <= 0 ) return;
            float delta = Time.time - mStart;
            if (delta < mEventFireTime) return;
            foreach (TimeEvent action in mActions)
            {
                if (action == null) continue;
                action.TimeAction( delta );
            }
            mEventFireTime = mRepeaterTime;
            mStart = Time.time;
        }
    }
}
