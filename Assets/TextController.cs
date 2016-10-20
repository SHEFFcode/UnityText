using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	public Text text;
	private enum _states {cell, mirror, sheets_0, lock_0, cell_mirror, sheets_1, lock_1, freedom};
	private _states _myState;

	// Use this for initialization
	void Start () {
		_myState = _states.cell;
	}
	
	// Update is called once per frame
	void Update () {
		print (_myState);
		if (_myState == _states.cell) {
			state_cell ();
		} else if (_myState == _states.sheets_0) {
			state_sheets_0 ();
		} else if (_myState == _states.lock_0) {
			state_lock_0();
		} else if (_myState == _states.mirror) {
			state_mirror();
		} else if (_myState == _states.lock_1) {
			state_lock_1();
		} else if (_myState == _states.freedom) {
			state_freedom();
		}
	}

	void state_cell() {
		text.text = "You are in a prison cell and are trying to escape. There are some dirty " + 
					"Sheets on the bed, a mirror on the wall and the door is locked from the outside \n \n" + 
					"Press S to view Sheets, M to view Mirror and L to view lock.";
		if (Input.GetKeyDown(KeyCode.S)) {
			_myState = _states.sheets_0;
		} else if (Input.GetKeyDown(KeyCode.M)) {
			_myState = _states.mirror;
		} else if (Input.GetKeyDown(KeyCode.L)) {
			_myState = _states.lock_0;
		}
	}

	void state_sheets_0() {
		text.text = "You can't believe you are sleeping in these things " + 
					"surely it is time someone changed them.  The pleasures of prison life I Guess! \n \n" + 
					"Press R to return to roaming your cell.";
		if (Input.GetKeyDown(KeyCode.R)) {
			_myState = _states.cell;
		}
	}

	void state_lock_0() {
		text.text = "This is one of those button locks.  You have no idea what the combination is " + 
					"You wish you could somehow see what the dirty buttons are. \n \n" + 
					"Press R to return to roaming your cell.";
		if (Input.GetKeyDown(KeyCode.R)) {
			_myState = _states.cell;
		}
	}

	void state_mirror() {
		text.text = "You hae found a mirror on the wall.  You can now use it to come back and see what the  " + 
					"dirty buttons are to try to figure out the combination. \n \n" + 
					"Press R to return to roaming your cell. Press M to use the mirror.";
		if (Input.GetKeyDown(KeyCode.R)) {
			_myState = _states.cell;
		} else if (Input.GetKeyDown (KeyCode.M)) {
			_myState = _states.lock_1;
		}
	}

	void state_lock_1() {
		text.text = "You are using the mirror and it allows you to see what the combinaiton is.  " + 
					"You punch in the combination, the door beeps and opens up. Will you leave? \n \n" + 
					"Press R to return to roaming your cell. Press F to escape to freedom.";
		if (Input.GetKeyDown(KeyCode.R)) {
			_myState = _states.cell;
		} else if (Input.GetKeyDown (KeyCode.F)) {
			_myState = _states.freedom;
		}
	}

	void state_freedom() {
		text.text = "Congrats! You have escaped!!";
	}
}
