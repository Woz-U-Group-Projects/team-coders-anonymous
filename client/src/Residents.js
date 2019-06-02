import React, { Component } from 'react';
import './Residents.css';

const _URL = 'https://24.164.14.197:5001/Residents';

class Residents extends Component 
{
	constructor(props) 
	{
		super(props);
		this.state = { promise: [], error: null, isLoaded: false, accts: [], acct: [] };
	}

	componentDidMount()
	{
		//Get a JSON List from the server
		fetch(_URL, 
				{
					crossDomain : true,
					method : 'POST',			// *GET, POST, PUT, DELETE, etc.
			//		mode : "cors",				// no-cors, cors, *same-origin
					cache : 'no-cache',			// *default, no-cache, reload, force-cache, only-if-cached
			//		credentials : 'omit',		// include, *same-origin, omit
			//		Accept : 'application/json',	//
			//		body : JSON.stringify({text: ''}),
					headers : {
							'Content-Type': 'application/json;',
//							'Access-Control-Request-Headers' : 'x-suiteRole-header',
//							'Access-Control-Request-Methods' : 'POST'
							},
				}
			)
		// Handle the JSON Promise
		.then(
				// Handle the Promise response.
				(response) => {
					// Debug code feedback
					//console.log("Sent fetch to "+_URL);

					// If the response is OK, collect the JSON list, else process the error.
					if(response.ok)
					{
						response.json()

						.then(
							// Handle the result
							(result) => {
								this.setState({ isLoaded: true, accts: result });
								// Debug code feedback
								//console.log("Result :");
								//console.log(result);
							},
							// Handle result Error
							(_Error3) => {
								this.setState({ isLoaded: true, error: _Error3 });
								this.setState({error: 'Result Error: '+_Error3});
							}
						)
			
						// Debug code feedback
						//console.log("Response :");
						//console.error(response);
					}
					// Process the error.
					else
					{
						this.setState({error: 'Response Error: '+response.statusText});
					};

					this.setState({ promise: response.statusText.toString() });
				}
			)
		// Handle the other types of errors.
		.catch((_Error1) => {
			this.setState({error: 'Fetch Error: '+_Error1});
		})
	}

	ShowResident = (res) => {
		this.setState({acct: res});
	};

	ShowUpdating = (act) => {
		alert("You pressed the "+act+". This functionality has not been updated. Yet!");
	};

	render()
	{
		const { error, isLoaded, accts, acct } = this.state;
		var _Msg = "Loading ...";

		if(error != null)
		{
			return(<section><h1 id='ErrorMsg'>{error}</h1></section>);
		}

		if(isLoaded)
		{
			_Msg = "Loaded";

			//{id, acctOwner, unitNum, lastName1, firstName1, storageNum, contactNum1, contactNum2, contactNum3, 
			//email1, email2, email3, email4, parkingSpot1, parkingSpot2}

			return(
				<section>
					<div id='NavBar'>
						{
							accts.map( acct => <a className='ResLink' key={acct.id} onClick={this.ShowResident.bind(this, acct)}> {acct.unitNum} - {acct.lastName1}</a>)
						}
					</div>
					<div id='ResDet'>
						<b className='line'>ID:			</b><u className='info'>{acct.id}			&nbsp;</u><br />
						<b className='line'>Owner:		</b><u className='info'>{acct.acctOwner}	&nbsp;</u><br />
						<b className='line'>Unit #:		</b><u className='info'>{acct.unitNum}		&nbsp;</u><br />
						<b className='line'>Last Name:	</b><u className='info'>{acct.lastName1}	&nbsp;</u><br />
						<b className='line'>First Name:	</b><u className='info'>{acct.firstName1}	&nbsp;</u><br />
						<b className='line'>Storage #:	</b><u className='info'>{acct.storageNum}	&nbsp;</u><br />
						<b className='line'>Contact #:	</b><u className='info'>{acct.contactNum1}	&nbsp;</u><br />
						<b className='line'>Contact #:	</b><u className='info'>{acct.contactNum2}	&nbsp;</u><br />
						<b className='line'>Contact #:	</b><u className='info'>{acct.contactNum3}	&nbsp;</u><br />
						<b className='line'>EMail:		</b><u className='info'>{acct.email1}		&nbsp;</u><br />
						<b className='line'>EMail:		</b><u className='info'>{acct.email2}		&nbsp;</u><br />
						<b className='line'>EMail:		</b><u className='info'>{acct.email3}		&nbsp;</u><br />
						<b className='line'>EMail:		</b><u className='info'>{acct.email4}		&nbsp;</u><br />
						<b className='line'>Parking #:	</b><u className='info'>{acct.parkingSpot1}	&nbsp;</u><br />
						<b className='line'>Parking #:	</b><u className='info'>{acct.parkingSpot2}	&nbsp;</u>
					</div>
					<div id='options'>
						<button className='option_button' onClick={this.ShowUpdating.bind(this, 'ADD'   )}>ADD   </button>
						<button className='option_button' onClick={this.ShowUpdating.bind(this, 'UPDATE')}>UPDATE</button>
						<button className='option_button' onClick={this.ShowUpdating.bind(this, 'DELETE')}>DELETE</button>
					</div>
				</section>
			);
		}

		return(<section><h1 id='ErrorMsg'>{error}</h1></section>);
	}
}

export default Residents;