import * as React from 'react';
import {
    PrimaryButton,
    TeamsComponentContext,
    ConnectedComponent,
    Panel,
    PanelBody,
    PanelHeader,
    PanelFooter,
    Surface,

    Radiobutton,
    RadiobuttonGroup,
    Checkbox,
    CheckboxGroup,
    Anchor,
    Dropdown,
    Input,
    Tab,
    TextArea,
    Toggle,
    ThemeStyle,
    IContext,
    IDropdownItemProps,
} from 'msteams-ui-components-react';
import { render } from 'react-dom';
import { TeamsBaseComponent, ITeamsBaseComponentProps, ITeamsBaseComponentState } from './TeamsBaseComponent';
// import * as $ from 'jquery'; build failed for this line of code.

/**
 * State for the componentgraphTab React component
 */
export interface ImsTeamsTabTabState extends ITeamsBaseComponentState {
    // MS Team SDK 'context' related state.
    groupId?: string | undefined;
    teamId?: string;
    channelId?: string;
    entityId?: string;
    subEntityId?: string;
    locale?: string;
    upn?: string;
    tid?: string;
    theme: ThemeStyle;

    // react component related state.
    toggledRadioButton?: boolean;
    selectedTab?: string;
    selectedChoice?: string;
    checkboxChecked?: boolean;
    notifySuccessResult?: any;
}

/**
 * Properties for the msTeamsTabTab React component
 */
export interface ImsTeamsTabTabProps extends ITeamsBaseComponentProps {

}

/**
 * Implementation of the componentgraph content page
 */
export class msTeamsTabTab extends TeamsBaseComponent<ImsTeamsTabTabProps, ImsTeamsTabTabState> {
    constructor(props, state) {
        super(props, state);
        this.state = {
            selectedTab: 'tabA',
            toggledRadioButton: false,
            fontSize: 12,
            theme: ThemeStyle.Dark,
            context: {} as IContext,
            selectedChoice: 'select member to display mail',
            checkboxChecked: false
        }
    }
    public componentWillMount() {
        this.updateTheme(this.getQueryVariable('theme'));
        this.setState({
            fontSize: this.pageFontSize()
        });

        if (this.inTeams()) {
            microsoftTeams.initialize();
            microsoftTeams.registerOnThemeChangeHandler(this.updateTheme);
            microsoftTeams.getContext(context => {
                this.setState({
                    groupId: context.groupId,
                    teamId: context.teamId,
                    channelId: context.channelId,
                    entityId: context.entityId,
                    subEntityId: context.subEntityId,
                    locale: context.locale,
                    upn: context.upn,
                    tid: context.tid,
                });
            });
        } else {
            this.setState({
                entityId: "This is not hosted in Microsoft Teams"
            });
        }
    }

    /** 
     * The render() method to create the UI of the tab
     */
    public render() {
        return (
            <TeamsComponentContext
                fontSize={this.state.fontSize}
                theme={this.state.theme}
            >

                <ConnectedComponent render={(props) => {
                    const { context } = props;
                    const { rem, font } = context;
                    const { sizes, weights } = font;
                    const styles = {
                        header: { ...sizes.title, ...weights.semibold },
                        section: { ...sizes.base, marginTop: rem(1.4), marginBottom: rem(1.4) },
                        footer: { ...sizes.xsmall }
                    }

                    return (
                        <Surface>
                            <Panel>
                                <PanelHeader>
                                    <div style={styles.header}>This is your tab</div>
                                </PanelHeader>
                                <PanelBody>
                                    <div style={styles.header}>Information from JS SDK context:</div>
                                    <div style={styles.section}>
                                        <div>groupId: {this.state.groupId} </div>
                                        <div>teamId: {this.state.teamId}</div>
                                        <div>channelId: {this.state.channelId}</div>
                                        <div>entityId: {this.state.entityId}</div>
                                        <div>locale: {this.state.locale}</div>
                                        <div>upn: {this.state.upn}</div>
                                        <div>tid: {this.state.tid}</div>
                                    </div>

                                    <div style={styles.header}>React UI Components:</div>
                                    <div style={styles.section}>
                                        <Radiobutton
                                            label='Radiobutton'
                                            selected={this.state.toggledRadioButton}
                                            value='Radiobutton value'
                                            onSelected={(checked, value) => {
                                                alert(`checked:${checked}, value:${value}`);
                                                this.setState({ toggledRadioButton: !this.state.toggledRadioButton })
                                            }} />
                                        <Radiobutton
                                            label='Radiobutton'
                                            selected={!this.state.toggledRadioButton}
                                            value='Radiobutton value'
                                            onSelected={(checked, value) => {
                                                alert(`checked:${checked}, value:${value}`);
                                                this.setState({ toggledRadioButton: this.state.toggledRadioButton })
                                            }} />
                                        <RadiobuttonGroup />
                                        <Checkbox label='Checkbox' value='Checkbox value' checked={false} onChecked={(checked, value) => { alert(`checked:${checked}, value:${value}`) }} />
                                        <CheckboxGroup label='Checkbox Group' values={['A', 'B', 'C', 'D']} onChecked={(values) => { alert(JSON.stringify(values)) }} />
                                        <Anchor />
                                        <Dropdown menuRightAlign={true}
                                            mainButtonText={this.state.selectedChoice}
                                            label='States'
                                            items={[
                                                { text: 'CA', onClick: () => this.setState({ selectedChoice: 'CA' }) },
                                                { text: 'NY', onClick: () => this.setState({ selectedChoice: 'NY' }) },
                                            ]}
                                        />
                                        <Input placeholder='Input' />
                                        <Tab tabs={[
                                            { text: 'tabA', onSelect: () => this.setState({ selectedTab: 'tabA' }), id: 'tabA' },
                                            { text: 'tabB', onSelect: () => this.setState({ selectedTab: 'tabB' }), id: 'tabB' }
                                        ]}
                                            selectedTabId={this.state.selectedTab}
                                            autoFocus={false} />
                                        <TextArea placeholder='Text Area' />
                                        <Toggle checked={!!this.state.toggledRadioButton} onToggle={() => this.setState({ toggledRadioButton: !this.state.toggledRadioButton })} />
                                        <PrimaryButton onClick={() => alert('it worked')}>Sign In</PrimaryButton>
                                    </div>
                                </PanelBody>
                                <PanelFooter>
                                    <div style={styles.footer}>(C) Copyright MicrosoftTeams.Tab</div>
                                </PanelFooter>
                            </Panel>
                        </Surface>
                    );
                }}>
                </ConnectedComponent>
            </TeamsComponentContext>
        );
    }
}