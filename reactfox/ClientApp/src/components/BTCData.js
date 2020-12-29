import React, { Component } from 'react';

export class BTCData extends Component {
    static displayName = BTCData.name;

    constructor(props) {
        super(props);
        this.state = { currencies: [], loading: true };
    }

    componentDidMount() {
        this.populateBTCData();
    }

    static renderForecastsTable(currencies) {
        return (
            <div>
                USD {currencies.usd.symbol}: {currencies.usd.last} {currencies.usd.buy} {currencies.usd.sell} 
            </div>


        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : BTCData.renderForecastsTable(this.state.currencies);

        return (
            <div>
                <h1 id="tabelLabel" >BTC fetcher</h1>
                <p>This component demonstrates fetching data from the BTC servers.</p>
                {contents}
            </div>
        );
    }

    async populateBTCData() {
        const response = await fetch('ExchangeRatesService');
        const data = await response.json();
        this.setState({ currencies: data, loading: false });
    }
}
